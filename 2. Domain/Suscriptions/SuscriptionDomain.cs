using _2._Domain.Clients;
using _2._Domain.Exceptions;
using _3._Data.Model;
using _3._Data.Reviews;
using _3._Data.Suscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Suscriptions
{
    public class SuscriptionDomain : ISuscriptionDomain
    {
        private ISuscriptionData _suscriptionData;
        private IClientDomain _clientDomain;
        public SuscriptionDomain(ISuscriptionData suscriptionData, IClientDomain clientDomain)
        {
            _suscriptionData = suscriptionData;
            _clientDomain = clientDomain;
        }

        public async Task<bool> CreateAsync(Suscription suscription)
        {
            await _clientDomain.GetByIdAsync(suscription.ClientId);
            await _clientDomain.ActivatePremiumAsync(suscription.ClientId);

            return await _suscriptionData.CreateAsync(suscription);
        }

        public async Task<List<Suscription>> GetAllByClientIdAsync(int clientId)
        {
            await _clientDomain.GetByIdAsync(clientId);
            return await _suscriptionData.GetAllByClientIdAsync(clientId);
        }

        public async Task<Suscription> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var suscriptionExiste = await _suscriptionData.GetByIdAsync(id);
            if (suscriptionExiste == null)
            {
                throw new NotFoundException("The suscription was not found");
            }
            return suscriptionExiste;
        }

        public async Task<bool> VerificateAsync(int id, int clientId)
        {
            var suscriptions = await GetAllByClientIdAsync(clientId);

            if (suscriptions != null)
            {
                Suscription lastSubscription = suscriptions.OrderByDescending(s => s.EndTime).FirstOrDefault();
                bool isPremium = (lastSubscription.EndTime > DateTime.UtcNow);
                if(isPremium)
                {
                    await _clientDomain.DesactivatePremiumAsync(clientId);
                }
                return true;

            }
            return true;
        }
    }
}
