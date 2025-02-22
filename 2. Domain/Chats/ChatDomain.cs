using _2._Domain.Clients;
using _2._Domain.Exceptions;
using _3._Data.Chats;
using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Chats
{
    public class ChatDomain : IChatDomain
    {
        private IChatData _chatData;
        private IClientDomain _clientDomain;
        public ChatDomain(IChatData chatData, IClientDomain clientDomain)
        {
            _chatData = chatData;
            _clientDomain = clientDomain;
        }

        public async Task<bool> CreateAsync(Chat chat)
        {
            if(chat.ClientId <= 0)
            {
                throw new InvalidActionException("The clientId is invalid");
            }
            if (chat.ClientTwoId <= 0)
            {
                throw new InvalidActionException("The clientTwoId is invalid");
            }
            await _clientDomain.GetByIdAsync(chat.ClientId);
            await _clientDomain.GetByIdAsync(chat.ClientTwoId);
            return await _chatData.CreateAsync(chat);
        }

        public async Task<List<Chat>> GetAllByClientIdAsync(int clientId)
        {
            await _clientDomain.GetByIdAsync(clientId);
            return await _chatData.GetAllByClientIdAsync(clientId);
        }

        public async Task<Chat> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var chatExiste = await _chatData.GetByIdAsync(id);
            if (chatExiste == null)
            {
                throw new NotFoundException("The chat was not found");
            }
            return chatExiste;
        }
    }
}
