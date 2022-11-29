using Microsoft.Extensions.Logging;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Services
{
    public class CategoryService : BaseDataService<ApplicationDBContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(
            IDbContextWrapper<ApplicationDBContext> contextWrapper,
            ILogger<BaseDataService<ApplicationDBContext>> baseLogger,
            ICategoryRepository categoryRepository,
            ILogger<CategoryService> logger)
            : base(contextWrapper, baseLogger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }

        public async Task<int> AddCategoryAsync(string categoryName, string description, string picture, bool active)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _categoryRepository.AddCategoryAsync(categoryName, description, picture, active);
                _logger.Log(LogLevel.Information, "Products category was sucessfully added");
                return id;
            });
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.DeleteCategoryAsync(id);
                return result;
            });
        }

        public async Task<CategoryModel?> GetCategoryAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.GetCategoryAsync(id);
                var tempResult = result;
                if (result == null)
                {
                    _logger.Log(LogLevel.Error, "Products category was not found");
                    return null!;
                }

                return new CategoryModel()
                {
                    Id = result.Id,
                    CategoryName = result.CategoryName,
                    Description = result.Description,
                    Picture = result.Picture,
                    Active = result.Active
                };
            });
        }

        public async Task<bool> UpdateCategoryAsync(int id, string property, string value)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _categoryRepository.UpdateCategoryAsync(id, property, value);
                if (result == false)
                {
                    _logger.Log(LogLevel.Error, $"An error occured during updating data.");
                }

                return result;
            });
        }
    }
}
