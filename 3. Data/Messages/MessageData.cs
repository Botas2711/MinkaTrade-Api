using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Messages
{
    public class MessageData : IMessageData
    {
        private MinkaTradeBD _minkaTradeBD;
        public MessageData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(Message message)
        {
            try
            {
                await _minkaTradeBD.Messages.AddAsync(message);
                await _minkaTradeBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Message>> GetAllAsycnc()
        {
            return await _minkaTradeBD.Messages.ToListAsync();
        }

        public async Task<List<Message>> GetAllByChatIdAsync(int chatId)
        {
            return await _minkaTradeBD.Messages.Where(p => p.ChatId == chatId).ToListAsync();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Messages.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Message message, int id)
        {
            try
            {
                Message messageToUpdate = await GetByIdAsync(id);

                messageToUpdate.content = message.content;
                messageToUpdate.SendById = message.SendById;
                messageToUpdate.ChatId = message.ChatId;

                _minkaTradeBD.Update(messageToUpdate);
                _minkaTradeBD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
