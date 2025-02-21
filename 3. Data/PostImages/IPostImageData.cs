using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.PostImages
{
    public interface IPostImageData
    {
        public Task<List<PostImage>> GetAllByPostIdAsync(int postId);
        public Task<PostImage> GetByIdAsync(int id);
        public Task<bool> CreateAsync(PostImage postImage);
        public Task<bool> UpdateAsync(PostImage postImage, int id);
        public Task<bool> DeleteAsync(int id);
    }
}
