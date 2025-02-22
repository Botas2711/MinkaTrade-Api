using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Chats
{
    public interface IChatDomain
    {
        public Task<bool> CreateAsync(Chat chat);
        public Task<Chat> GetByIdAsync(int id);
        public Task<List<Chat>> GetAllByClientIdAsync(int clientId);
    }
}
