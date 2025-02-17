using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class ClientRequest
    {
        [Required]
        [MaxLength(80)]
        public string first_name { get; set; }

        [Required]
        [MaxLength(120)]
        public string last_name { get; set; }

        [Required]
        public DateTime birthdate { get; set; }

        [Required]
        [MaxLength(8)]
        public string dni { get; set; }

        [Required]
        [MaxLength(1)]
        public string gender { get; set; }

        [Required]
        [MaxLength(150)]
        public string email { get; set; }

        [Required]
        [MaxLength(9)]
        public string phone_number { get; set; }
    }
}
