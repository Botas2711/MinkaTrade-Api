using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Messages
{
    public interface IMessageDomain
    {
        public Task<Message> GetByIdAsync(int id);
        public Task<List<Message>> GetAllByChatIdAsync(int chatId);
        public Task<bool> CreateAsync(Message message);
        public Task<bool> UpdateAsync(Message message, int id);
    }
}
