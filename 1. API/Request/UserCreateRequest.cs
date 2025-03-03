using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class UserCreateRequest
    {
        [Required(ErrorMessage = "The Username is required")]
        [MaxLength(40)]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password is required")]
        [MaxLength(40)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Roles is required")]
        public string Roles { get; set; }
    }
}
