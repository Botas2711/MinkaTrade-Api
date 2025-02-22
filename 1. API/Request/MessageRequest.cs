using _3._Data.Model;
using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class MessageRequest
    {
        [Required(ErrorMessage = "The content is required")]
        [MaxLength(200)]
        public string content { get; set; }

        [Required(ErrorMessage = "The sendById is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The sendById must be greater than 0")]
        public int SendById { get; set; }

        [Required(ErrorMessage = "The chatId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The chatId must be greater than 0")]
        public int ChatId { get; set; }
    }
}
