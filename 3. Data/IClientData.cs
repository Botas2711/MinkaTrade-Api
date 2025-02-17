using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data
{
    public interface IClientData
    {
        public Client GetById(int id);
        public Client GetByPhoneNumber(string phoneNumber);
        public List<Client> GetAll();
        public bool Create(Client client);
        public bool Update(Client client, int id);
    }
}
