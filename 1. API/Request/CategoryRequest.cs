using _3._Data.Model;
using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class CategoryRequest
    {
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        List<Post> Posts { get; set; } = new List<Post>();
    }
}
