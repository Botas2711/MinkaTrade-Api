using _2._Domain.Exceptions;
using _2._Domain.Token;
using _3._Data.Clients;
using _3._Data.Model;
using _3._Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Users
{
    public class UserDomain : IUserDomain
    {
        private IUserData _userData;
        private ITokenService _tokenService;
        public UserDomain(IUserData userData, ITokenService tokenService)
        {
            _userData = userData;
            _tokenService = tokenService;
        }

        public async Task<bool> CreateAsync(User user)
        {
            var userExisteUsername = await _userData.GetByUsernameAsync(user.Username);

            if (userExisteUsername != null)
            {
                throw new DuplicateDataException("A user with this Username already exists");
            }

            user.Password = EncryptPassword(user.Password);
            return await _userData.CreateAsync(user);
        }

        public async Task<UserToken> LoginAsync(User user)
        {
            var userExiste = await _userData.GetByUsernameAsync(user.Username);
            if (userExiste == null || EncryptPassword(user.Password) != userExiste.Password)
            {
                throw new InvalidActionException("The username or password is incorrect");
            }
            if(userExiste.Enabled == false)
            {
                throw new InvalidActionException("The user is disabled");
            }
            var token = await _tokenService.GenerateToken(userExiste.Username);

            return new UserToken
            {
                Id = userExiste.Id,
                Roles = userExiste.Roles,
                Token = token
            };

        }

        public string EncryptPassword(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new InvalidActionException("Error in base64Encode");
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var userExiste = await _userData.GetByIdAsync(id);
            if (userExiste == null)
            {
                throw new NotFoundException("The user was not found");
            }
            return userExiste;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var clientExiste = await GetByIdAsync(id);
            if(clientExiste.Enabled == false)
            {
                throw new InvalidActionException("The user is already disabled");
            }
            return await _userData.DeleteAsync(id);
        }
    }
}
