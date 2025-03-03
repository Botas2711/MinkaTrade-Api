using _2._Domain.Exceptions;
using _2._Domain.Users;
using _3._Data.Clients;
using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2._Domain.Clients
{
    public class ClientDomain : IClientDomain
    {
        private IClientData _clientData;
        private IUserDomain _userDomain;
        public ClientDomain(IClientData clientData, IUserDomain userDomain)
        {
            _clientData = clientData;
            _userDomain = userDomain;
        }
        private int CalculateAge(DateTime birthdate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthdate.Year;
            if (birthdate.Date > today.AddYears(-age)) age--;
            return age;
        }
        public async Task<bool> CreateAsync(Client client)
        {
            await _userDomain.GetByIdAsync(client.UserId);
            if (string.IsNullOrWhiteSpace(client.PhoneNumber) || client.PhoneNumber.Length != 9)
            {
                throw new InvalidActionException("The phone number must have exactly 9 numbers");
            }

            if (string.IsNullOrWhiteSpace(client.Dni) || client.Dni.Length != 8)
            {
                throw new InvalidActionException("The DNI must have exactly 8 numbers");
            }

            if (string.IsNullOrWhiteSpace(client.Gender) || client.Gender.Length != 1)
            {
                throw new InvalidActionException("The gender must be exactly 1 character long");
            }

            if(CalculateAge(client.Birthdate) < 18)
            {
                throw new InvalidActionException("The client must be at least 18 years old");
            }

            var clientExistePhoneNumber = await _clientData.GetByPhoneNumberAsync(client, false);
            var clientExisteEmail = await _clientData.GetByEmailAsync(client, false);
            var clientExisteDni = await _clientData.GetByDniAsync(client, false);

            if (clientExistePhoneNumber != null)
            {
                throw new DuplicateDataException("A client with this phone number already exists");
            }

            if (clientExisteEmail != null)
            {
                throw new DuplicateDataException("A client with this email is already registered");
            }

            if (clientExisteDni != null)
            {
                throw new DuplicateDataException("A client with this DNI is already registered");
            }

            return await _clientData.CreateAsync(client);
        }


        public async Task<bool> UpdateAsync(Client client, int id)
        {
            await _userDomain.GetByIdAsync(client.UserId);
            await GetByIdAsync(id);

            if (string.IsNullOrWhiteSpace(client.PhoneNumber) || client.PhoneNumber.Length != 9)
            {
                throw new InvalidActionException("The phone number must have exactly 9 numbers");
            }

            if (string.IsNullOrWhiteSpace(client.Dni) || client.Dni.Length != 8)
            {
                throw new InvalidActionException("The DNI must have exactly 8 numbers");
            }

            if (string.IsNullOrWhiteSpace(client.Gender) || client.Gender.Length != 1)
            {
                throw new InvalidActionException("The gender must be exactly 1 character long");
            }

            if (CalculateAge(client.Birthdate) < 18)
            {
                throw new InvalidActionException("The client must be at least 18 years old");
            }

            var clientExistePhoneNumber = await _clientData.GetByPhoneNumberAsync(client, true);
            var clientExisteEmail = await _clientData.GetByEmailAsync(client, true);
            var clientExisteDni = await _clientData.GetByDniAsync(client, true);

            if (clientExistePhoneNumber != null && clientExistePhoneNumber.Id != id)
            {
                throw new DuplicateDataException("A client with this phone number already exists");
            }

            if (clientExisteEmail != null && clientExisteEmail.Id != id)
            {
                throw new DuplicateDataException("A client with this email is already registered");
            }

            if (clientExisteDni != null && clientExisteDni.Id != id)
            {
                throw new DuplicateDataException("A client with this DNI is already registered");
            }

            return await _clientData.UpdateAsync(client, id);
        }

        public async Task<bool> ActivatePremiumAsync(int id)
        {
            var clientExiste = await GetByIdAsync(id);
            if(clientExiste != null && clientExiste.HasPremiun == true)
            {
                throw new InvalidActionException("The client already has a premium plan");
            }

            return await _clientData.ActivatePremiumAsync(id);
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var clientExiste = await _clientData.GetByIdAsync(id);
            if (clientExiste == null)
            {
                throw new NotFoundException("The client was not found");
            }
            return clientExiste;
        }

        public async Task<bool> DesactivatePremiumAsync(int id)
        {
            var clientExiste = await GetByIdAsync(id);
            if(clientExiste != null && clientExiste.HasPremiun != true)
            {
                throw new InvalidActionException("The client does not have any premium plan");
            }
            return await _clientData.DesactivatePremiumAsync(id);
        }
    }
}
