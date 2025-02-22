using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Posts
{
    public interface IPostDomain
    {
        public Task<Post> GetByIdAsync(int id);
        public Task<List<Post>> GetAllByClientIdAsync(int clientId);
        public Task<List<Post>> GetAllByTitleAsync(string title);
        public Task<List<Post>> GetAllByStatusAsync(bool status);
        public Task<List<Post>> GetAllByRangePriceAsync(decimal initialPrice, decimal finalPrice);
        public Task<List<Post>> GetAllByRangeDateAsync(DateTime initialDate, DateTime finalDate);
        public Task<List<Post>> GetAllByCategoryIdAsync(int categoryId);
        public Task<bool> CreateAsync(Post post);
        public Task<bool> UpdateAsync(Post post, int id);
        public Task<bool> DeleteAsync(int id);
    }
}
