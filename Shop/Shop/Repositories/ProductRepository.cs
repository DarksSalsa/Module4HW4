using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ProductRepository(IDbContextWrapper<ApplicationDBContext> contextWrapper)
        {
            _dbContext = contextWrapper.DbContext;
        }

        public async Task<int> AddProductAsync(int supplierID, int categoryID, string sKU, string iDSKU, int vendorProductId, string productName, string productDescription, int quantityPerUnit, decimal unitPrice, string mSRP, string availableSize, string availableColors, string size, string color, decimal discount, string unitWeight, int unitsInStock, int unitsOnOrder, string reorderLevel, bool productAvailable, bool discountAvailable, string picture, int ranking, string note)
        {
            var result = await _dbContext.Products.AddAsync(new ProductEntity()
            {
                SupplierID = supplierID,
                CategoryID = categoryID,
                SKU = sKU,
                IDSKU = iDSKU,
                VendorProductID = vendorProductId,
                ProductName = productName,
                ProductDescription = productDescription,
                QuantityPerUnit = quantityPerUnit,
                UnitPrice = unitPrice,
                MSRP = mSRP,
                AvailableSize = availableSize,
                AvailableColors = availableColors,
                Size = size,
                Color = color,
                Discount = discount,
                UnitWeight = unitWeight,
                UnitsInStock = unitsInStock,
                UnitsOnOrder = unitsOnOrder,
                ReorderLevel = reorderLevel,
                ProductAvailable = productAvailable,
                DiscountAvailable = discountAvailable,
                Picture = picture,
                Ranking = ranking,
                Note = note,
            });

            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await GetProductAsync(id);
            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ProductEntity?> GetProductAsync(int id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<ProductEntity>?> GetProductByCategoryIdAsync(int id)
        {
            return await _dbContext.Products.Where(w => w.CategoryID == id).ToListAsync();
        }

        public async Task<IEnumerable<ProductEntity>?> GetProductBySupplierIdAsync(int id)
        {
            return await _dbContext.Products.Where(w => w.SupplierID == id).ToListAsync();
        }

        public async Task<bool> UpdateProductAsync(int id, string property, string value)
        {
            var product = await GetProductAsync(id);

            if (product != null)
            {
                var changingValue = product.GetType().GetProperty(property);
                if (changingValue != null)
                {
                    changingValue.SetValue(product, value, null);
                    _dbContext.Products.Update(product);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
