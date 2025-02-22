using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Reviews
{
    public interface IReviewDomain
    {
        public Task<Review> GetByIdAsync(int id);
        public Task<List<Review>> GetAllByClientIdAsync(int clientId);
        public Task<List<Review>> GetAllOrderByRateDescAsync(int clientId);
        public Task<List<Review>> GetAllOrderByRateAscAsync(int clientId);
        public Task<bool> CreateAsync(Review review);
        public Task<bool> UpdateAsync(Review review, int id);
        public Task<bool> DeleteAsync(int id);
    }
}
