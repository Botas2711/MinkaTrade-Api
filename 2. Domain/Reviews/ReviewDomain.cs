using _2._Domain.Clients;
using _2._Domain.Exceptions;
using _3._Data.Model;
using _3._Data.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Reviews
{
    public class ReviewDomain : IReviewDomain
    {
        private IReviewData _reviewData;
        private IClientDomain _clientDomain;
        public ReviewDomain(IReviewData reviewData, IClientDomain clientDomain)
        {
            _reviewData = reviewData;
            _clientDomain = clientDomain;
        }

        public async Task<bool> CreateAsync(Review review)
        {
            if(review.Rate <= 0)
            {
                throw new InvalidActionException("The rate must be greater than 0");
            }
            return await _reviewData.CreateAsync(review);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            await GetByIdAsync(id);
            return await _reviewData.DeleteAsync(id);
        }

        public async Task<List<Review>> GetAllByClientIdAsync(int clientId)
        {
            await _clientDomain.GetByIdAsync(clientId);
            return await _reviewData.GetAllByClientIdAsync(clientId);
        }

        public async Task<List<Review>> GetAllOrderByRateDescAsync(int clientId)
        {
            await _clientDomain.GetByIdAsync(clientId);
            return await _reviewData.GetAllOrderByRateDescAsync(clientId);
        }

        public async Task<List<Review>> GetAllOrderByRateAscAsync(int clientId)
        {
            await _clientDomain.GetByIdAsync(clientId);
            return await _reviewData.GetAllOrderByRateAscAsync(clientId);
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new InvalidActionException("The id is invalid");
            }
            var reviewExiste = await _reviewData.GetByIdAsync(id);
            if (reviewExiste == null)
            {
                throw new NotFoundException("The review was not found");
            }
            return reviewExiste;
        }

        public async Task<bool> UpdateAsync(Review review, int id)
        {
            await GetByIdAsync(id);
            if (review.Rate <= 0)
            {
                throw new InvalidActionException("The rate must be greater than 0");
            }
            return await _reviewData.UpdateAsync(review, id);
        }
    }
}
