using BlazorAirBnb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.DataAccess.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<bool> AddCategory(Category category);

        Task<bool> DeleteCategory(int id);

        Task<Category?> GetCategoryById(int id);

        Task<bool> UpdateCategory(Category category);
    }
}
