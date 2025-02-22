using _2._Domain.Chats;
using _2._Domain.Exceptions;
using _3._Data.Messages;
using _3._Data.Model;
using _3._Data.PostImages;
using _3._Data.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Messages
{
    public class MessageDomain : IMessageDomain
    {
        private IMessageData _messageData;
        private IChatDomain _chatDomain;
        public MessageDomain(IMessageData messageData, IChatDomain chatDomain)
        {
            _messageData = messageData;
            _chatDomain = chatDomain;
        }

        public async Task<bool> CreateAsync(Message message)
        {
            return await _messageData.CreateAsync(message);
        }

        public async Task<List<Message>> GetAllByChatIdAsync(int chatId)
        {
            await _chatDomain.GetByIdAsync(chatId);
            return await _messageData.GetAllByChatIdAsync(chatId);
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var messageExiste = await _messageData.GetByIdAsync(id);
            if (messageExiste == null)
            {
                throw new NotFoundException("The message was not found");
            }
            return messageExiste;
        }

        public async Task<bool> UpdateAsync(Message message, int id)
        {
            await GetByIdAsync(id);
            return await _messageData.UpdateAsync(message, id);
        }
    }
}
