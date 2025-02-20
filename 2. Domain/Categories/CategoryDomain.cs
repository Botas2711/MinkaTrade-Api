using _2._Domain.Exceptions;
using _3._Data.Categories;
using _3._Data.Clients;
using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Categories
{
    public class CategoryDomain : ICategoryDomain
    {
        private ICategoryData _categoryData;
        public CategoryDomain(ICategoryData categoryData)
        {
            _categoryData = categoryData;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            var categoryExiste = await _categoryData.GetByName(category, false);
            if (categoryExiste != null)
            {
                throw new DuplicateDataException("A category with this name already exists");
            }
            return await _categoryData.CreateAsync(category);
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var categoryExiste = await _categoryData.GetByIdAsync(id);
            if (categoryExiste == null)
            {
                throw new NotFoundException("The category was not found");
            }
            return await _categoryData.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Category category, int id)
        {
            var categoryExiste = await _categoryData.GetByName(category, true);
            if (categoryExiste != null && categoryExiste.Id != id)
            {
                throw new DuplicateDataException("A category with this name already exists");
            }
            return await _categoryData.UpdateAsync(category, id);
        }
    }
}
