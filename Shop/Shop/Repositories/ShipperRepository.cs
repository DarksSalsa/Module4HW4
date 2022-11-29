using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Repositories
{
    public class ShipperRepository : IShipperRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ShipperRepository(IDbContextWrapper<ApplicationDBContext> contextWrapper)
        {
            _dbContext = contextWrapper.DbContext;
        }

        public async Task<int> AddShipperAsync(string companyName, string phone)
        {
            var innerShipper = new ShipperEntity() { CompanyName = companyName, Phone = phone };
            var result = await _dbContext.Shippers.AddAsync(innerShipper);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeleteShipperAsync(int id)
        {
            var shipper = await GetShipperAsync(id);
            if (shipper != null)
            {
                _dbContext.Shippers.Remove(shipper);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<ShipperEntity?> GetShipperAsync(int id)
        {
            return await _dbContext.Shippers.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> UpdateShipperAsync(int id, string property, string value)
        {
            var shipper = await GetShipperAsync(id);

            if (shipper != null)
            {
                var changingValue = shipper.GetType().GetProperty(property);
                if (changingValue != null)
                {
                    changingValue.SetValue(shipper, value, null);
                    _dbContext.Shippers.Update(shipper);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
