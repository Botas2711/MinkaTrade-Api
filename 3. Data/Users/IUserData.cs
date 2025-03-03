using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Users
{
    public interface IUserData
    {
        public Task<bool> CreateAsync(User user);
        public Task<User> GetByIdAsync(int id);
        public Task<bool> DeleteAsync(int id);
        public Task<List<User>> GetAllAsycnc();
        public Task<User> GetByUsernameAsync(string username);
    }
}
