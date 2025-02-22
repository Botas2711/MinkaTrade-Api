using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Chat
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        // Cliente que inicia el chat
        public int ClientOneId { get; set; }
        public Client ClientOne { get; set; }

        // Cliente que recibe el chat
        public int ClientTwoId { get; set; }
        public Client ClientTwo { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
