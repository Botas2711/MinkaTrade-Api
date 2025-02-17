using _3._Data;
using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain
{
    public class ClientDomain : IClientDomain
    {
        private IClientData _clientData;
        public ClientDomain(IClientData clientData)
        {
            _clientData = clientData;
        }
        public bool Create(Client client)
        {
            var clientExiste = _clientData.GetByPhoneNumber(client.phone_number);

            if (clientExiste == null)
            {
                return _clientData.Create(client);
            }
            else
            {
                return false;
            }
        }

        public bool Update(Client client, int id)
        {
            var clientExiste = _clientData.GetByPhoneNumber(client.phone_number);

            if (clientExiste == null)
            {
                return _clientData.Update(client, id);
            }
            else
            {
                return false;
            }
        }
    }
}
