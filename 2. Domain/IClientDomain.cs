using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain
{
    public interface IClientDomain
    {
        public bool Create(Client client);
        public bool Update(Client client, int id);
    }
}
