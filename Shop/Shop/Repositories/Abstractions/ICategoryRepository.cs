using Shop.Data.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface ICategoryRepository
    {
        Task<int> AddCategoryAsync(string categoryName, string description, string picture, bool active);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, string property, string value);
        Task<CategoryEntity?> GetCategoryAsync(int id);
    }
}
