using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Premiuns
{
    public class PremiunData : IPremiunData
    {
        private MinkaTradeBD _minkaTradeBD;
        public PremiunData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(Premiun premiun)
        {
            try
            {
                await _minkaTradeBD.Premiuns.AddAsync(premiun);
                await _minkaTradeBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<Premiun> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Premiuns.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Premiun premiun, int id)
        {
            try
            {
                Premiun premiunToUpdate = await GetByIdAsync(id);

                premiunToUpdate.Price = premiun.Price;

                _minkaTradeBD.Update(premiunToUpdate);
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
