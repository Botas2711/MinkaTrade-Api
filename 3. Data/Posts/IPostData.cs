using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Posts
{
    public interface IPostData
    {
        public Task<Post> GetByIdAsync(int id);
        public Task<List<Post>> GetAllByClientIdAsync(int clientId);
        public Task<List<Post>> GetAllByTitleIdAsync(string title);
        public Task<List<Post>> GetAllByStatusIdAsync(bool status);
        public Task<List<Post>> GetAllByRangePriceIdAsync(decimal initialPrice, decimal finalPrice);
        public Task<List<Post>> GetAllByRangeDateIdAsync(DateTime initialDate, DateTime finalDate);
        public Task<List<Post>> GetAllByCategoryIdAsync(int categoryId);
        public Task<List<Post>> GetAllAsycnc();
        public Task<bool> CreateAsync(Post post);
        public Task<bool> UpdateAsync(Post post, int id);
        public Task<bool> DeleteAsync(int id);
    }
}
