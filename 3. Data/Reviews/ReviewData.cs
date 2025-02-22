using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace _3._Data.Reviews
{
    public class ReviewData : IReviewData
    {
        private MinkaTradeBD _minkaTradeBD;
        public ReviewData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(Review review)
        {
            try
            {
                await _minkaTradeBD.Reviews.AddAsync(review);
                await _minkaTradeBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Review reviewToDelete = await GetByIdAsync(id);
                _minkaTradeBD.Remove(reviewToDelete);
                _minkaTradeBD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Review>> GetAllByClientIdAsync(int clientId)
        {
            return await _minkaTradeBD.Reviews.Where(p => p.ClientId == clientId).ToListAsync();
        }

        public async Task<List<Review>> GetAllOrderByRateDescAsync(int clientId)
        {
            return await _minkaTradeBD.Reviews.Where(p => p.ClientId == clientId).OrderByDescending(p => p.Rate).ToListAsync();
        }
        public async Task<List<Review>> GetAllOrderByRateAscAsync(int clientId)
        {
            return await _minkaTradeBD.Reviews.Where(p => p.ClientId == clientId).OrderBy(p => p.Rate).ToListAsync();
        }

        public async Task<Review> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Reviews.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Review review, int id)
        {
            try
            {
                Review reviewToUpdate = await GetByIdAsync(id);

                reviewToUpdate.Description = review.Description;
                reviewToUpdate.Rate = review.Rate;

                _minkaTradeBD.Update(reviewToUpdate);
                _minkaTradeBD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
