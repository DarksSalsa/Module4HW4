using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.Extensions.Logging;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Services
{
    public class ProductService : BaseDataService<ApplicationDBContext>, IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductService> _logger;

        public ProductService(
            IDbContextWrapper<ApplicationDBContext> contextWrapper,
            ILogger<BaseDataService<ApplicationDBContext>> baseLogger,
            IProductRepository productRepository,
            ILogger<ProductService> logger)
            : base(contextWrapper, baseLogger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public async Task<int> AddProductAsync(
            int supplierID,
            int categoryID,
            string sKU,
            string iDSKU,
            int vendorProductId,
            string productName,
            string productDescription,
            int quantityPerUnit,
            decimal unitPrice,
            string mSRP,
            string availableSize,
            string availableColors,
            string size,
            string color,
            decimal discount,
            string unitWeight,
            int unitsInStock,
            int unitsOnOrder,
            string reorderLevel,
            bool productAvailable,
            bool discountAvailable,
            string picture,
            int ranking,
            string note)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _productRepository.AddProductAsync(
                    supplierID,
                    categoryID,
                    sKU,
                    iDSKU,
                    vendorProductId,
                    productName,
                    productDescription,
                    quantityPerUnit,
                    unitPrice,
                    mSRP,
                    availableSize,
                    availableColors,
                    size,
                    color,
                    discount,
                    unitWeight,
                    unitsInStock,
                    unitsOnOrder,
                    reorderLevel,
                    productAvailable,
                    discountAvailable,
                    picture,
                    ranking,
                    note);
                _logger.Log(LogLevel.Information, "Product was sucessfully added");
                return id;
            });
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.DeleteProductAsync(id);
                return result;
            });
        }

        public async Task<ProductModel?> GetProductAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.GetProductAsync(id);

                if (result == null)
                {
                    _logger.Log(LogLevel.Error, "Product was not found");
                    return null!;
                }

                return new ProductModel()
                {
                    Id = result.Id,
                    SupplierID = result.SupplierID,
                    CategoryID = result.CategoryID,
                    SKU = result.SKU,
                    IDSKU = result.IDSKU,
                    VendorProductID = result.VendorProductID,
                    ProductName = result.ProductName,
                    ProductDescription = result.ProductDescription,
                    QuantityPerUnit = result.QuantityPerUnit,
                    UnitPrice = result.UnitPrice,
                    MSRP = result.MSRP,
                    AvailableSize = result.AvailableSize,
                    AvailableColors = result.AvailableColors,
                    Size = result.Size,
                    Color = result.Color,
                    Discount = result.Discount,
                    UnitWeight = result.UnitWeight,
                    UnitsInStock = result.UnitsInStock,
                    UnitsOnOrder = result.UnitsOnOrder,
                    ReorderLevel = result.ReorderLevel,
                    ProductAvailable = result.ProductAvailable,
                    DiscountAvailable = result.DiscountAvailable,
                    Picture = result.Picture,
                    Ranking = result.Ranking,
                    Note = result.Note,
                };
            });
        }

        public async Task<IReadOnlyList<ProductModel>?> GetProductByCategoryIdAsync(int id)
        {
            var data = await _productRepository.GetProductByCategoryIdAsync(id);
            if (data == null)
            {
                _logger.Log(LogLevel.Warning, $"For this category Id = {id} products were not found.");
                return null;
            }

            return data!.Select(result => new ProductModel()
            {
                Id = result.Id,
                SupplierID = result.SupplierID,
                CategoryID = result.CategoryID,
                SKU = result.SKU,
                IDSKU = result.IDSKU,
                VendorProductID = result.VendorProductID,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                QuantityPerUnit = result.QuantityPerUnit,
                UnitPrice = result.UnitPrice,
                MSRP = result.MSRP,
                AvailableSize = result.AvailableSize,
                AvailableColors = result.AvailableColors,
                Size = result.Size,
                Color = result.Color,
                Discount = result.Discount,
                UnitWeight = result.UnitWeight,
                UnitsInStock = result.UnitsInStock,
                UnitsOnOrder = result.UnitsOnOrder,
                ReorderLevel = result.ReorderLevel,
                ProductAvailable = result.ProductAvailable,
                DiscountAvailable = result.DiscountAvailable,
                Picture = result.Picture,
                Ranking = result.Ranking,
                Note = result.Note,
            }).ToList();
        }

        public async Task<IReadOnlyList<ProductModel>?> GetProductBySupplierIdAsync(int id)
        {
            var data = await _productRepository.GetProductBySupplierIdAsync(id);
            if (data == null)
            {
                _logger.Log(LogLevel.Warning, $"For this supplier Id = {id} products were not found.");
                return null;
            }

            return data!.Select(result => new ProductModel()
            {
                Id = result.Id,
                SupplierID = result.SupplierID,
                CategoryID = result.CategoryID,
                SKU = result.SKU,
                IDSKU = result.IDSKU,
                VendorProductID = result.VendorProductID,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                QuantityPerUnit = result.QuantityPerUnit,
                UnitPrice = result.UnitPrice,
                MSRP = result.MSRP,
                AvailableSize = result.AvailableSize,
                AvailableColors = result.AvailableColors,
                Size = result.Size,
                Color = result.Color,
                Discount = result.Discount,
                UnitWeight = result.UnitWeight,
                UnitsInStock = result.UnitsInStock,
                UnitsOnOrder = result.UnitsOnOrder,
                ReorderLevel = result.ReorderLevel,
                ProductAvailable = result.ProductAvailable,
                DiscountAvailable = result.DiscountAvailable,
                Picture = result.Picture,
                Ranking = result.Ranking,
                Note = result.Note,
            }).ToList();
        }

        public async Task<bool> UpdateProductAsync(int id, string property, string value)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _productRepository.UpdateProductAsync(id, property, value);
                if (result == false)
                {
                    _logger.Log(LogLevel.Error, $"An error occured during updating data.");
                }

                return result;
            });
        }
    }
}
