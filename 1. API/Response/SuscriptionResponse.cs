using _3._Data.Model;

namespace _1._API.Response
{
    public class SuscriptionResponse
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PremiunId { get; set; }
        public int ClientId { get; set; }
    }
}
