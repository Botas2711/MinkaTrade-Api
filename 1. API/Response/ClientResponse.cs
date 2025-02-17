namespace _1._API.Response
{
    public class ClientResponse
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birthdate { get; set; }
        public string dni { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public byte[]? profile_picture { get; set; }
    }
}
