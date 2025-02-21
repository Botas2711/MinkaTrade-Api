namespace _1._API.Response
{
    public class PostResponse
    {
        public int Id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? updated_date { get; set; }
    }
}
