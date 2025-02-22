using _3._Data.Model;

namespace _1._API.Response
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string description { get; set; }
        public int rate { get; set; }
        public DateTime created_date { get; set; }
    }
}
