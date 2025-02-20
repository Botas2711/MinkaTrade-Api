using _3._Data.Context;
using _3._Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Categories
{
    public class CategoryData : ICategoryData
    {
        private MinkaTradeBD _minkaTradeBD;
        public CategoryData(MinkaTradeBD minkaTradeBD)
        {
            _minkaTradeBD = minkaTradeBD;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            try
            {
                await _minkaTradeBD.Categories.AddAsync(category);
                await _minkaTradeBD.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Category>> GetAllAsycnc()
        {
            return await _minkaTradeBD.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _minkaTradeBD.Categories.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Category> GetByName(Category category, bool accion)
        {
            // Si accion es true significa que estamos actualizando
            if (accion)
            {
                return await _minkaTradeBD.Categories.Where(p => p.Name == category.Name && p.Id != category.Id).FirstOrDefaultAsync();
            }
            return await _minkaTradeBD.Categories.Where(p => p.Name == category.Name).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateAsync(Category category, int id)
        {
            try
            {
                Category categoryToUpdate = await GetByIdAsync(id);
                categoryToUpdate.Name = category.Name;
                _minkaTradeBD.Update(categoryToUpdate);
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
