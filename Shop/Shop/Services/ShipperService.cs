using Microsoft.Extensions.Logging;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Services
{
    public class ShipperService : BaseDataService<ApplicationDBContext>, IShipperService
    {
        private readonly IShipperRepository _shipperRepository;
        private readonly ILogger<ShipperService> _logger;

        public ShipperService(
            IDbContextWrapper<ApplicationDBContext> contextWrapper,
            ILogger<BaseDataService<ApplicationDBContext>> baseLogger,
            IShipperRepository shipperRepository,
            ILogger<ShipperService> logger)
            : base(contextWrapper, baseLogger)
        {
            _shipperRepository = shipperRepository;
            _logger = logger;
        }

        public async Task<int> AddShipperAsync(string companyName, string phone)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _shipperRepository.AddShipperAsync(companyName, phone);
                _logger.Log(LogLevel.Information, "Shipper was sucessfully added");
                return id;
            });
        }

        public async Task<bool> DeleteShipperAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _shipperRepository.DeleteShipperAsync(id);
                return result;
            });
        }

        public async Task<ShipperModel?> GetShipperAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _shipperRepository.GetShipperAsync(id);

                if (result == null)
                {
                    _logger.Log(LogLevel.Error, "Shipper was not found");
                    return null!;
                }

                return new ShipperModel()
                {
                    Id = result.Id,
                    CompanyName = result.CompanyName,
                    Phone = result.Phone
                };
            });
        }

        public async Task<bool> UpdateShipperAsync(int id, string property, string value)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _shipperRepository.UpdateShipperAsync(id, property, value);
                if (result == false)
                {
                    _logger.Log(LogLevel.Error, $"An error occured during updating data.");
                }

                return result;
            });
        }
    }
}
