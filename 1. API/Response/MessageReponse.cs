using _3._Data.Model;

namespace _1._API.Response
{
    public class MessageReponse
    {
        public int Id { get; set; }
        public string content { get; set; }
        public DateTime created_date { get; set; }
        public int SendById { get; set; }
        public int ChatId { get; set; }
    }
}
