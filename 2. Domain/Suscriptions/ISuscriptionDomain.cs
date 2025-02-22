using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Suscriptions
{
    public interface ISuscriptionDomain
    {
        public Task<bool> CreateAsync(Suscription suscription);
        public Task<bool> VerificateAsync(int id, int clientId);
        public Task<Suscription> GetByIdAsync(int id);
        public Task<List<Suscription>> GetAllByClientIdAsync(int clientId);
    }
}
