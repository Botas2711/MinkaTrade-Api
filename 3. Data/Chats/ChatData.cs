using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Chats
{
    public class ChatData : IChatData
    {
        private MinkaTradeBD _minkaTradeBD;
        public ChatData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(Chat chat)
        {
            try
            {
                await _minkaTradeBD.Chats.AddAsync(chat);
                await _minkaTradeBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Chat>> GetAllAsycnc()
        {
            return await _minkaTradeBD.Chats.ToListAsync();
        }

        public async Task<List<Chat>> GetAllByClientIdAsync(int clientId)
        {
            return await _minkaTradeBD.Chats.Where(p => p.ClientId == clientId).ToListAsync();
        }

        public async Task<Chat> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Chats.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
