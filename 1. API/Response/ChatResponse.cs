using _3._Data.Model;

namespace _1._API.Response
{
    public class ChatResponse
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ClientOneId { get; set; }
        public int ClientTwoId { get; set; }
    }
}
