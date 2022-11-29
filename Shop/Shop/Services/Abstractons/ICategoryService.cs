using Shop.Data.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface ICategoryService
    {
        Task<int> AddCategoryAsync(string categoryName, string description, string picture, bool active);
        Task<bool> DeleteCategoryAsync(int id);
        Task<bool> UpdateCategoryAsync(int id, string property, string value);
        Task<CategoryModel?> GetCategoryAsync(int id);
    }
}
