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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public string Dni { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public bool HasPremiun { get; set; }

        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Chat> ChatsAsSender { get; set; } = new List<Chat>();
        public List<Chat> ChatsAsReceiver { get; set; } = new List<Chat>();
        public List<Suscription> Suscriptions { get; set; } = new List<Suscription>();
    }
}
