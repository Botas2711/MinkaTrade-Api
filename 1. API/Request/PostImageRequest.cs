using _3._Data.Model;
using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class PostImageRequest
    {
        [Required(ErrorMessage = "The image is required")]
        public byte[] Images { get; set; }

        [Required(ErrorMessage = "The postId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The postId must be greater than 0")]
        public int PostId { get; set; }
    }
}
