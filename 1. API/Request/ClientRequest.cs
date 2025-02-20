using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class ClientRequest
    {
        [Required(ErrorMessage = "The first_name is required")]
        [MaxLength(80)]
        public string first_name { get; set; }

        [Required(ErrorMessage = "The last_name is required")]
        [MaxLength(120)]
        public string last_name { get; set; }

        [Required(ErrorMessage = "The birthdate is required")]
        public DateTime birthdate { get; set; }

        [Required(ErrorMessage = "The dni is required")]
        public string dni { get; set; }

        [Required(ErrorMessage = "The gender is required")]
        [MaxLength(1)]
        public string gender { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [MaxLength(150)]
        public string email { get; set; }

        [Required(ErrorMessage = "The phone_number is required")]
        public string phone_number { get; set; }
    }
}
