using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryRepository(IDbContextWrapper<ApplicationDBContext> contextWrapper)
        {
            _dbContext = contextWrapper.DbContext;
        }

        public async Task<int> AddCategoryAsync(string categoryName, string description, string picture, bool active)
        {
            var innerCategory = new CategoryEntity()
            {
                CategoryName = categoryName,
                Description = description,
                Picture = picture,
                Active = active
            };

            var result = await _dbContext.Category.AddAsync(innerCategory);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await GetCategoryAsync(id);
            if (category != null)
            {
                _dbContext.Category.Remove(category);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(int id)
        {
            return await _dbContext.Category
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> UpdateCategoryAsync(int id, string property, string value)
        {
            var category = await GetCategoryAsync(id);

            if (category != null)
            {
                var changingValue = category.GetType().GetProperty(property);
                if (changingValue != null)
                {
                    changingValue.SetValue(category, value, null);
                    _dbContext.Category.Update(category);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
