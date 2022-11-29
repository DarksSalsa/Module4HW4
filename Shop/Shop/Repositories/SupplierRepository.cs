using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public SupplierRepository(IDbContextWrapper<ApplicationDBContext> contextWrapper)
        {
            _dbContext = contextWrapper.DbContext;
        }

        public async Task<int> AddSupplierAsync(
            string companyName,
            string contactFName,
            string contactLName,
            string contactTitle,
            string address1,
            string address2,
            string city,
            string state,
            string postalCode,
            string country,
            string phone,
            string fax,
            string email,
            string url,
            string paymentMethods,
            string discountType,
            string notes,
            bool discountAvailable,
            string currentOrder,
            string logo,
            string customerId,
            string sizeURL)
        {
            var innerSupplier = new SupplierEntity()
            {
                CompanyName = companyName,
                ContactFName = contactFName,
                ContactLName = contactLName,
                ContactTitle = contactTitle,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Fax = fax,
                Email = email,
                URL = url,
                PaymentMethods = paymentMethods,
                DiscountType = discountType,
                Notes = notes,
                DiscountAvailable = discountAvailable,
                CurrentOrder = currentOrder,
                Logo = logo,
                CustomerID = customerId,
                SizeURL = sizeURL
            };
            var result = await _dbContext.Suppliers.AddAsync(innerSupplier);
            await _dbContext.SaveChangesAsync();

            return result.Entity.Id;
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            var supplier = await GetSupplierAsync(supplierId);
            if (supplier != null)
            {
                _dbContext.Suppliers.Remove(supplier);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<SupplierEntity?> GetSupplierAsync(int supplierId)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(f => f.Id == supplierId);
        }

        public async Task<bool> UpdateSupplerAsync(int supplierId, string property, string value)
        {
            var supplier = await GetSupplierAsync(supplierId);

            if (supplier != null)
            {
                var changingValue = supplier.GetType().GetProperty(property);
                if (changingValue != null)
                {
                    changingValue.SetValue(supplier, value, null);
                    _dbContext.Suppliers.Update(supplier);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
