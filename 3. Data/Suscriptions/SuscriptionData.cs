using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Suscriptions
{
    public class SuscriptionData : ISuscriptionData
    {
        private MinkaTradeBD _minkaTradeBD;
        public SuscriptionData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(Suscription suscription)
        {
            try
            {
                await _minkaTradeBD.Suscriptions.AddAsync(suscription);
                await _minkaTradeBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Suscription>> GetAllByClientIdAsync(int clientId)
        {
            return await _minkaTradeBD.Suscriptions.Where(p => p.ClientId == clientId).ToListAsync();
        }

        public async Task<Suscription> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Suscriptions.Where(p => p.Id == id).FirstOrDefaultAsync();
        }
    }
}
