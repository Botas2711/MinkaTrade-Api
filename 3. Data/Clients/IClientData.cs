using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Clients
{
    public interface IClientData
    {
        public Task<Client> GetByIdAsync(int id);
        public Task<Client> GetByPhoneNumberAsync(Client client, bool accion);
        public Task<Client> GetByEmailAsync(Client client, bool accion);
        public Task<Client> GetByDniAsync(Client client, bool accion);
        public Task<bool> ActivatePremium(int id);
        public Task<List<Client>> GetAllAsycnc();
        public Task<bool> CreateAsync(Client client);
        public Task<bool> UpdateAsync(Client client, int id);
    }
}
