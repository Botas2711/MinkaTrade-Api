using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data
{
    public class ClientData : IClientData
    {
        private MinkaTradeBD _minkaTradeBD;
        public ClientData(MinkaTradeBD minkaTradeBD)
        {
            this._minkaTradeBD = minkaTradeBD;
        }
        public bool Create(Client client)
        {
            try
            {
                _minkaTradeBD.Clients.Add(client);
                _minkaTradeBD.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Client>> GetAllAsycnc()
        {
            return await _minkaTradeBD.Clients.ToListAsync();
        }

        public Client GetById(int id)
        {
            return _minkaTradeBD.Clients.Where(p => p.Id == id).First();
        }

        public Client GetByPhoneNumber(string phoneNumber)
        {
            return _minkaTradeBD.Clients.Where(p => p.phone_number == phoneNumber).FirstOrDefault();
        }

        public bool Update(Client client, int id)
        {
            try
            {
                var clientToUpdate = _minkaTradeBD.Clients.Where(p => p.Id == id).First();

                clientToUpdate.first_name = client.first_name;
                clientToUpdate.last_name = client.last_name;
                clientToUpdate.dni = client.dni;
                clientToUpdate.birthdate = client.birthdate;
                clientToUpdate.gender = client.gender;
                clientToUpdate.email = client.email;
                clientToUpdate.phone_number = client.phone_number;
                clientToUpdate.profile_picture = client.profile_picture;

                _minkaTradeBD.Update(clientToUpdate);
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
