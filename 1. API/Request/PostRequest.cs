using _3._Data.Model;
using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class PostRequest
    {
        [Required(ErrorMessage = "The title is required")]
        [MaxLength(100)]
        public string title { get; set; }

        [Required(ErrorMessage = "The price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be greater than 0")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "The description is required")]
        [MaxLength(200)]
        public string description { get; set; }

        [Required(ErrorMessage = "The categoryId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The categoryId must be greater than 0")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The clientId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The clientId must be greater than 0")]
        public int ClientId { get; set; }
    }
}
