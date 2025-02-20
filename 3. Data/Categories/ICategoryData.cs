using _3._Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._Data.Categories
{
    public interface ICategoryData
    {
        public Task<Category> GetByIdAsync(int id);
        public Task<List<Category>> GetAllAsycnc();
        public Task<bool> CreateAsync(Category category);
        public Task<bool> UpdateAsync(Category category, int id);
        public Task<Category> GetByName(Category category, bool accion);
    }
}
