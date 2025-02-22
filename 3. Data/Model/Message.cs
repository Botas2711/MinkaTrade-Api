using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string content { get; set; }
        public DateTime created_date { get; set; }

        public int SendById { get; set; }
        public Client SendBy { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
