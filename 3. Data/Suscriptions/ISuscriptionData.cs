using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Suscriptions
{
    public interface ISuscriptionData
    {
        public Task<bool> CreateAsync(Suscription suscription);
        public Task<Suscription> GetByIdAsync(int id);
        public Task<List<Suscription>> GetAllByClientIdAsync(int clientId);
    }
}
