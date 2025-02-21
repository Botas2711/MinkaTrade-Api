using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.PostImages
{
    public interface IPostImageDomain
    {
        public Task<bool> CreateAsync(PostImage postImage);
        public Task<bool> UpdateAsync(PostImage postImage, int id);
        public Task<bool> DeleteAsync(int id);
        public Task<PostImage> GetByIdAsync(int id);
        public Task<List<PostImage>> GetAllByPostIdAsync(int postId);
    }
}
