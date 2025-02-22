using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class ClientRequest
    {
        [Required(ErrorMessage = "The FirstName is required")]
        [MaxLength(80)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "The LastName is required")]
        [MaxLength(120)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "The Birthdate is required")]
        public DateTime Birthdate { get; set; }

        [Required(ErrorMessage = "The Dni is required")]
        public string Dni { get; set; }

        [Required(ErrorMessage = "The Gender is required")]
        [MaxLength(1)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        [MaxLength(150)]
        public string Email { get; set; }

        [Required(ErrorMessage = "The PhoneNumber is required")]
        public string PhoneNumber { get; set; }
    }
}
