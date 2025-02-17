using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Model
{
    public class PostImage
    {
        public int Id { get; set; }
        public byte[] Images { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}