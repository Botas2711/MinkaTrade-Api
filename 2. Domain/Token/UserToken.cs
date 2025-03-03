using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Token
{
    public class UserToken
    {
        public int Id { get; set; }
        public string Roles { get; set; }
        public string Token { get; set; }
    }
}
