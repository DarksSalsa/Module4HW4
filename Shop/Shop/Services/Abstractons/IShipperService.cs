using Shop.Data.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface IShipperService
    {
        Task<int> AddShipperAsync(string companyName, string phone);
        Task<bool> DeleteShipperAsync(int id);
        Task<bool> UpdateShipperAsync(int id, string property, string value);
        Task<ShipperModel?> GetShipperAsync(int id);
    }
}
