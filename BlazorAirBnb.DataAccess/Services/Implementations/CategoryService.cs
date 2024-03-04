using BlazorAirBnb.DataAccess.Services.Interfaces;
using BlazorAirBnb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAirBnb.DataAccess.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly AirBnbDbContext? _airBnbDbContext;

        public CategoryService(AirBnbDbContext airBnbDbContext)
        {
            _airBnbDbContext = airBnbDbContext;
        }


        public async Task<bool> AddCategory(Category category)
        {
            var categoryResp = await _airBnbDbContext!.Categories.AddAsync(category);
            await _airBnbDbContext!.SaveChangesAsync();
            if (categoryResp is not null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _airBnbDbContext!.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is not null)
            {
                _airBnbDbContext!.Categories.Remove(category);
                await _airBnbDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var categories = await _airBnbDbContext!.Categories.ToListAsync<Category>();
            return categories;
        }


        public async Task<Category?> GetCategoryById(int id)
        {
            var category = await _airBnbDbContext!.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category == null)
            {
                return null;
            }
            return category;

        }

        public Task<bool> UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
