using _3._Data.Model;

namespace _1._API.Response
{
    public class ReviewResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Rate { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
