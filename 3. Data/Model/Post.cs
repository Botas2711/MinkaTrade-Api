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
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}

        public List <PostImage> PostImages { get; set; } = new List<PostImage>();
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
    }
}
