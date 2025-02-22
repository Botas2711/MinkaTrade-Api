using _3._Data.Model;
using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class PostRequest
    {
        [Required(ErrorMessage = "The Title is required")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The Description is required")]
        [MaxLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "The categoryId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The categoryId must be greater than 0")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "The clientId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The clientId must be greater than 0")]
        public int ClientId { get; set; }
    }
}
