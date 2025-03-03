using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Users
{
    public class UserData : IUserData
    {
        private MinkaTradeBD _minkaTradeBD;
        public UserData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(User user)
        {
            try
            {
                await _minkaTradeBD.Users.AddAsync(user);
                await _minkaTradeBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                User userToUpdate = await GetByIdAsync(id);
                userToUpdate.Enabled = false;
                _minkaTradeBD.Update(userToUpdate);
                _minkaTradeBD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<User>> GetAllAsycnc()
        {
            return await _minkaTradeBD.Users.Where(p => p.Enabled == true).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Users.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _minkaTradeBD.Users.Where(p => p.Username == username).FirstOrDefaultAsync();
        }
    }
}
