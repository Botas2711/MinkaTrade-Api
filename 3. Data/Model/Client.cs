using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birthdate { get; set; }
        public string dni { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public byte[]? profile_picture { get; set; }
        public bool hasPremiun { get; set; }
    }
}
