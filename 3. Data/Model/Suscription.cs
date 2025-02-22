using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Suscription
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int PremiunId { get; set; }
        public Premiun Premiun { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
