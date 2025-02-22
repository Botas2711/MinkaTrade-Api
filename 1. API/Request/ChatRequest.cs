using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class ChatRequest
    {
        [Required(ErrorMessage = "The clientOneId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The clientOneId must be greater than 0")]
        public int ClientOneId { get; set; }

        [Required(ErrorMessage = "The clientTwoId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The clientTwoId must be greater than 0")]
        public int ClientTwoId { get; set; }
    }
}
