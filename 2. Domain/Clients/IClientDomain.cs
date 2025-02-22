using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2._Domain.Clients
{
    public interface IClientDomain
    {
        public Task<bool> CreateAsync(Client client);
        public Task<bool> UpdateAsync(Client client, int id);
        public Task<bool> ActivatePremiumAsync(int id);
        public Task<bool> DesactivatePremiumAsync(int id);
        public Task<Client> GetByIdAsync(int id);
    }
}
