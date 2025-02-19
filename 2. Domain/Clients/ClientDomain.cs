using _2._Domain.Exceptions;
using _3._Data.Clients;
using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2._Domain.Clients
{
    public class ClientDomain : IClientDomain
    {
        private IClientData _clientData;
        public ClientDomain(IClientData clientData)
        {
            _clientData = clientData;
        }

        public async Task<bool> CreateAsync(Client client)
        {
            if (client.phone_number.Length != 9)
            {
                throw new InvalidActionException("The phone number must have exactly 9 numbers.");
            }

            var clientExiste = await _clientData.GetByPhoneNumberAsync(client, false);
            if (clientExiste != null)
            {
                throw new DuplicateDataException("A client with this phone number already exists.");
            }

            return await _clientData.CreateAsync(client);
        }


        public async Task<bool> UpdateAsync(Client client, int id)
        {
            if (client.dni.Length != 8)
            {
                throw new Exception("The DNI must have exactly 8 numbers");
            }

            if (client.phone_number.Length != 9)
            {
                throw new Exception("The phone number must have exactly 9 numbers");
            }

            var clientExistePhoneNumber = _clientData.GetByPhoneNumberAsync(client, true);
            var clientExisteEmail = _clientData.GetByEmailAsync(client, true);
            var clientExisteDni = _clientData.GetByDniAsync(client, true);

            if (clientExistePhoneNumber != null && clientExistePhoneNumber.Id != id)
            {
                throw new Exception("The email is already registered");
            }

            if (clientExisteEmail != null && clientExisteEmail.Id != id)
            {
                throw new Exception("The email is already registered");
            }

            if (clientExisteDni != null && clientExisteDni.Id != id)
            {
                throw new Exception("The DNI is already registered");
            }

            if ((clientExistePhoneNumber == null || clientExistePhoneNumber.Id == id) &&
                (clientExisteEmail == null || clientExisteEmail.Id == id) &&
                (clientExisteDni == null || clientExisteDni.Id == id))
            {
                return await _clientData.UpdateAsync(client, id);
            }
            else
            {
                return false;
            }
        }
    }
}
