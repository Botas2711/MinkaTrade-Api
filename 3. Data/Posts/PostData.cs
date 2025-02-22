using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Posts
{
    public class PostData : IPostData
    {
        private MinkaTradeBD _minkaTradeBD;
        public PostData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(Post post)
        {
            try
            {
                await _minkaTradeBD.Posts.AddAsync(post);
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
                Post postToDelete = await GetByIdAsync(id);
                _minkaTradeBD.Remove(postToDelete);
                _minkaTradeBD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Post>> GetAllAsycnc()
        {
            return await _minkaTradeBD.Posts.ToListAsync();
        }

        public async Task<List<Post>> GetAllByCategoryIdAsync(int categoryId)
        {
            return await _minkaTradeBD.Posts.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Post>> GetAllByClientIdAsync(int clientId)
        {
            return await _minkaTradeBD.Posts.Where(p => p.ClientId == clientId).ToListAsync();
        }

        public async Task<List<Post>> GetAllByRangeDateAsync(DateTime initialDate, DateTime finalDate)
        {
            return await _minkaTradeBD.Posts.Where(p => p.CreatedDate >= initialDate && p.CreatedDate <= finalDate).ToListAsync();
        }

        public async Task<List<Post>> GetAllByRangePriceAsync(decimal initialPrice, decimal finalPrice)
        {
            return await _minkaTradeBD.Posts.Where(p => p.Price >= initialPrice && p.Price <= finalPrice).ToListAsync();
        }

        public async Task<List<Post>> GetAllByStatusAsync(bool status)
        {
            return await _minkaTradeBD.Posts.Where(p => p.Status == status).ToListAsync();
        }

        public async Task<List<Post>> GetAllByTitleAsync(string title)
        {
            return await _minkaTradeBD.Posts.Where(p => p.Title.Contains(title)).ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Posts.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Post post, int id)
        {
            try
            {
                Post postToUpdate = await GetByIdAsync(id);

                postToUpdate.Title = post.Title;
                postToUpdate.Description = post.Description;
                postToUpdate.Price = post.Price;
                postToUpdate.CategoryId = post.CategoryId;
                postToUpdate.UpdatedDate = DateTime.Now;

                _minkaTradeBD.Update(postToUpdate);
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
