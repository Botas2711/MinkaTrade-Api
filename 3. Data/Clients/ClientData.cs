using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Clients
{
    public class ClientData : IClientData
    {
        private MinkaTradeBD _minkaTradeBD;
        public ClientData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }
        public async Task<bool> ActivatePremiumAsync(int id)
        {
            try
            {
                Client clientToUpdate = await GetByIdAsync(id);
                clientToUpdate.hasPremiun = true;
                _minkaTradeBD.Update(clientToUpdate);
                _minkaTradeBD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateAsync(Client client)
        {
            try
            {
                await _minkaTradeBD.Clients.AddAsync(client);
                await _minkaTradeBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<List<Client>> GetAllAsycnc()
        {
            return await _minkaTradeBD.Clients.ToListAsync();
        }

        public async Task<Client> GetByDniAsync(Client client, bool accion)
        {
            // Si accion es true significa que estamos actualizando
            if (accion)
            {
                return await _minkaTradeBD.Clients.Where(p => p.dni == client.dni && p.Id != client.Id).FirstOrDefaultAsync();
            }
            return await _minkaTradeBD.Clients.Where(p => p.dni == client.dni).FirstOrDefaultAsync();
        }

        public async Task<Client> GetByEmailAsync(Client client, bool accion)
        {
            // Si accion es true significa que estamos actualizando
            if (accion)
            {
                return await _minkaTradeBD.Clients.Where(p => p.email == client.email && p.Id != client.Id).FirstOrDefaultAsync();
            }
            return await _minkaTradeBD.Clients.Where(p => p.email == client.email).FirstOrDefaultAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Clients.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Client> GetByPhoneNumberAsync(Client client, bool accion)
        {
            if (accion)
            {
                return await _minkaTradeBD.Clients.Where(p => p.phone_number == client.phone_number && p.Id != client.Id).FirstOrDefaultAsync();
            }
            return await _minkaTradeBD.Clients.Where(p => p.phone_number == client.phone_number).FirstOrDefaultAsync();
        }


        public async Task<bool> UpdateAsync(Client client, int id)
        {
            try
            {
                Client clientToUpdate = await GetByIdAsync(id);

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
