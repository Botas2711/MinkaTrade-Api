using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Messages
{
    public interface IMessageData
    {
        public Task<Message> GetByIdAsync(int id);
        public Task<List<Message>> GetAllByChatIdAsync(int chatId);
        public Task<List<Message>> GetAllAsycnc();
        public Task<bool> CreateAsync(Message message);
        public Task<bool> UpdateAsync(Message message, int id);
    }
}
