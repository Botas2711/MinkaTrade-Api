using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.PostImages
{
    public class PostImageData : IPostImageData
    {
        private MinkaTradeBD _minkaTradeBD;
        public PostImageData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(PostImage postImage)
        {
            try
            {
                await _minkaTradeBD.PostImages.AddAsync(postImage);
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
                PostImage postImageToDelete = await GetByIdAsync(id);
                _minkaTradeBD.Remove(postImageToDelete);
                _minkaTradeBD.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<PostImage>> GetAllByPostIdAsync(int postId)
        {
            return await _minkaTradeBD.PostImages.Where(p => p.PostId == postId).ToListAsync();
        }

        public async Task<PostImage> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.PostImages.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(PostImage postImage, int id)
        {
            try
            {
                PostImage postImageToUpdate = await GetByIdAsync(id);
                postImageToUpdate.Images = postImage.Images;
                _minkaTradeBD.Update(postImageToUpdate);
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
