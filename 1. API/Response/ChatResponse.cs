using _3._Data.Model;

namespace _1._API.Response
{
    public class ChatResponse
    {
        public int Id { get; set; }
        public DateTime created_date { get; set; }
        public int ClientId { get; set; }
        public int ClientTwoId { get; set; }
    }
}
