using _3._Data.Model;
using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class ReviewRequest
    {
        [Required(ErrorMessage = "The description is required")]
        [MaxLength(200)]
        public string description { get; set; }

        [Required(ErrorMessage = "The rate is required")]
        [Range(1, 5, ErrorMessage = "The rate must be between 1 and 5")]
        public int rate { get; set; }

        [Required(ErrorMessage = "The clientId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The clientId must be greater than 0")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "The sendById is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The sendById must be greater than 0")]
        public int SendById { get; set; }
    }
}
