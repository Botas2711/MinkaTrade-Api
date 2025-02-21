using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Post
    {
        public int Id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public bool status { get; set; }
        public DateTime created_date { get; set; }
        public DateTime? updated_date { get; set;}

        public List <PostImage> PostImages { get; set; } = new List<PostImage>();
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
