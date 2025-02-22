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
                clientToUpdate.HasPremiun = true;
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

        public async Task<bool> DesactivatePremiumAsync(int id)
        {
            try
            {
                Client clientToUpdate = await GetByIdAsync(id);
                clientToUpdate.HasPremiun = false;
                _minkaTradeBD.Update(clientToUpdate);
                _minkaTradeBD.SaveChanges();
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
                return await _minkaTradeBD.Clients.Where(p => p.Dni == client.Dni && p.Id != client.Id).FirstOrDefaultAsync();
            }
            return await _minkaTradeBD.Clients.Where(p => p.Dni == client.Dni).FirstOrDefaultAsync();
        }

        public async Task<Client> GetByEmailAsync(Client client, bool accion)
        {
            // Si accion es true significa que estamos actualizando
            if (accion)
            {
                return await _minkaTradeBD.Clients.Where(p => p.Email == client.Email && p.Id != client.Id).FirstOrDefaultAsync();
            }
            return await _minkaTradeBD.Clients.Where(p => p.Email == client.Email).FirstOrDefaultAsync();
        }

        public async Task<Client> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Clients.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Client> GetByPhoneNumberAsync(Client client, bool accion)
        {
            if (accion)
            {
                return await _minkaTradeBD.Clients.Where(p => p.PhoneNumber == client.PhoneNumber && p.Id != client.Id).FirstOrDefaultAsync();
            }
            return await _minkaTradeBD.Clients.Where(p => p.PhoneNumber == client.PhoneNumber).FirstOrDefaultAsync();
        }


        public async Task<bool> UpdateAsync(Client client, int id)
        {
            try
            {
                Client clientToUpdate = await GetByIdAsync(id);

                clientToUpdate.FirstName = client.FirstName;
                clientToUpdate.LastName = client.LastName;
                clientToUpdate.Dni = client.Dni;
                clientToUpdate.Birthdate = client.Birthdate;
                clientToUpdate.Gender = client.Gender;
                clientToUpdate.Email = client.Email;
                clientToUpdate.PhoneNumber = client.PhoneNumber;
                clientToUpdate.ProfilePicture = client.ProfilePicture;

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
