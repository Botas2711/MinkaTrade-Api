using _2._Domain.Token;
using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Users
{
    public interface IUserDomain
    {
        public Task<UserToken> LoginAsync(User user);
        public Task<bool> CreateAsync(User user);
        public Task<User> GetByIdAsync(int id);
        public Task<bool> DeleteAsync(int id);
    }
}
