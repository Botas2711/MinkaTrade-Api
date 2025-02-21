using _2._Domain.Categories;
using _2._Domain.Clients;
using _2._Domain.Exceptions;
using _3._Data.Clients;
using _3._Data.Model;
using _3._Data.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Posts
{
    public class PostDomain : IPostDomain
    {
        private IPostData _postData;
        private IClientDomain _clientDomain;
        private ICategoryDomain _categoryDomain;
        public PostDomain(IPostData postData, IClientDomain clientDomain, ICategoryDomain categoryDomain)
        {
            _postData = postData;
            _clientDomain = clientDomain;
            _categoryDomain = categoryDomain;
        }

        public async Task<bool> CreateAsync(Post post)
        {
            return await _postData.CreateAsync(post);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await GetByIdAsync(id);
            return await _postData.DeleteAsync(id);
        }

        public async Task<List<Post>> GetAllByCategoryIdAsync(int categoryId)
        {
            await _categoryDomain.GetByIdAsync(categoryId);
            return await _postData.GetAllByCategoryIdAsync(categoryId);
        }

        public async Task<List<Post>> GetAllByClientIdAsync(int clientId)
        {
            await _clientDomain.GetByIdAsync(clientId);
            return await _postData.GetAllByClientIdAsync(clientId);
        }

        public async Task<List<Post>> GetAllByRangeDateIdAsync(DateTime initialDate, DateTime finalDate)
        {
            if (initialDate > finalDate)
            {
                throw new InvalidActionException("The final date must be greater than the initial date");
            }
            return await _postData.GetAllByRangeDateIdAsync(initialDate, finalDate);
        }

        public async Task<List<Post>> GetAllByRangePriceIdAsync(decimal initialPrice, decimal finalPrice)
        {
            if(initialPrice < 0)
            {
                throw new InvalidActionException("The initial price must be greater than 0");
            }
            if (finalPrice < 0)
            {
                throw new InvalidActionException("The final price must be greater than 0 ");
            }
            if(initialPrice > finalPrice)
            {
                throw new InvalidActionException("The final price must be higher than the initial price");
            }
            return await _postData.GetAllByRangePriceIdAsync(initialPrice, finalPrice);
        }

        public async Task<List<Post>> GetAllByStatusIdAsync(bool status)
        {
            if (status == null)
            {
                throw new InvalidActionException("The status is null");
            }
            return await _postData.GetAllByStatusIdAsync(status);
        }

        public async Task<List<Post>> GetAllByTitleIdAsync(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new InvalidActionException("The title is empty");
            }
            return await _postData.GetAllByTitleIdAsync(title);
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var postExiste = await _postData.GetByIdAsync(id);
            if (postExiste == null)
            {
                throw new NotFoundException("The post was not found");
            }
            return postExiste;
        }

        public async Task<bool> UpdateAsync(Post post, int id)
        {
            await GetByIdAsync(id);
            return await _postData.UpdateAsync(post, id);
        }
    }
}
