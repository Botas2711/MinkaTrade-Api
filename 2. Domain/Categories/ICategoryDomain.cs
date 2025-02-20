using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._Domain.Categories
{
    public interface ICategoryDomain
    {
        public Task<bool> CreateAsync(Category category);
        public Task<bool> UpdateAsync(Category category, int id);
        public Task<Category> GetByIdAsync(int id);
    }
}
