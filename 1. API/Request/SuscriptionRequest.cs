using _3._Data.Model;
using System.ComponentModel.DataAnnotations;

namespace _1._API.Request
{
    public class SuscriptionRequest
    {
        [Required(ErrorMessage = "The premiunId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The premiunId must be greater than 0")]
        public int PremiunId { get; set; }

        [Required(ErrorMessage = "The clientId is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The clientId must be greater than 0")]
        public int ClientId { get; set; }
    }
}
