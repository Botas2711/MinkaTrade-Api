using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<Post> Posts { get; set; } = new List<Post>();
    }
}