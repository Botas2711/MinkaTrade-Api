using _2._Domain.Exceptions;
using _3._Data.Clients;
using _3._Data.Model;
using _3._Data.PostImages;
using _3._Data.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.PostImages
{
    public class PostImageDomain : IPostImageDomain
    {
        private IPostImageData _postImageData;
        private IPostData _postData;
        public PostImageDomain(IPostImageData postImageData, IPostData postData)
        {
            _postImageData = postImageData;
            _postData = postData;
        }

        public async Task<bool> CreateAsync(PostImage postImage)
        {
            var postExiste = await _postData.GetByIdAsync(postImage.PostId);
            if (postExiste == null)
            {
                throw new NotFoundException("The post was not found");
            }
            return await _postImageData.CreateAsync(postImage);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await GetByIdAsync(id);
            return await _postImageData.DeleteAsync(id);
        }

        public async Task<List<PostImage>> GetAllByPostIdAsync(int postId)
        {
            var postExiste = await _postData.GetByIdAsync(postId);
            if (postExiste == null)
            {
                throw new NotFoundException("The post was not found");
            }
            return await _postImageData.GetAllByPostIdAsync(postId);
        }

        public async Task<PostImage> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var postImageExiste = await _postImageData.GetByIdAsync(id);
            if (postImageExiste == null)
            {
                throw new NotFoundException("The postImage was not found");
            }
            return await _postImageData.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(PostImage postImage, int id)
        {
            await GetByIdAsync(id);
            return await _postImageData.UpdateAsync(postImage, id);
        }
    }
}
