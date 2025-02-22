using _2._Domain.Clients;
using _2._Domain.Exceptions;
using _3._Data.Model;
using _3._Data.Premiuns;
using _3._Data.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Premiuns
{
    public class PremiunDomain : IPremiunDomain
    {
        private IPremiunData _premiunData;
        public PremiunDomain(IPremiunData premiunData)
        {
            _premiunData = premiunData;
        }

        public async Task<bool> CreateAsync(Premiun premiun)
        {
            return await _premiunData.CreateAsync(premiun);
        }

        public async Task<Premiun> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var premiunExiste = await _premiunData.GetByIdAsync(id);
            if (premiunExiste == null)
            {
                throw new NotFoundException("The premiun was not found");
            }
            return premiunExiste;
        }

        public async Task<bool> UpdateAsync(Premiun premiun, int id)
        {
            await GetByIdAsync(id);
            return await _premiunData.UpdateAsync(premiun, id);
        }
    }
}
