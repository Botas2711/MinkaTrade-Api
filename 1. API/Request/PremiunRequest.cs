using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class PremiunRequest
    {
        [Required(ErrorMessage = "The Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price must be greater than 0")]
        public decimal Price { get; set; }
    }
}
