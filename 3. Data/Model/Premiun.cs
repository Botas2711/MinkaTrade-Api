using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Premiun
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public List<Suscription> Suscriptions { get; set; } = new List<Suscription>();

    }
}
