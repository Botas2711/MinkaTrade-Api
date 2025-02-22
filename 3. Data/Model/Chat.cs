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
        public DateTime created_date { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ClientTwoId { get; set; }
        public Client ClientTwo { get; set; }

        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
