using Shop.Data.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface IShipperRepository
    {
        Task<int> AddShipperAsync(string companyName, string phone);
        Task<bool> DeleteShipperAsync(int id);
        Task<bool> UpdateShipperAsync(int id, string property, string value);
        Task<ShipperEntity?> GetShipperAsync(int id);
    }
}
