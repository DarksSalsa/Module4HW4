using Microsoft.Extensions.Logging;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Services
{
    public class SupplierService : BaseDataService<ApplicationDBContext>, ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ILogger<SupplierService> _logger;

        public SupplierService(
            IDbContextWrapper<ApplicationDBContext> contextWrapper,
            ILogger<BaseDataService<ApplicationDBContext>> baseLogger,
            ISupplierRepository supplierRepository,
            ILogger<SupplierService> logger)
            : base(contextWrapper, baseLogger)
        {
            _supplierRepository = supplierRepository;
            _logger = logger;
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
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _supplierRepository.AddSupplierAsync(
            companyName,
            contactFName,
            contactLName,
            contactTitle,
            address1,
            address2,
            city,
            state,
            postalCode,
            country,
            phone,
            fax,
            email,
            url,
            paymentMethods,
            discountType,
            notes,
            discountAvailable,
            currentOrder,
            logo,
            customerId,
            sizeURL);
                _logger.Log(LogLevel.Information, "Supplier was sucessfully added");
                return id;
            });
        }

        public async Task<bool> DeleteSupplierAsync(int supplierId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.DeleteSupplierAsync(supplierId);
                return result;
            });
        }

        public async Task<SupplierModel> GetSupplierAsync(int supplierId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.GetSupplierAsync(supplierId);

                if (result == null)
                {
                    _logger.Log(LogLevel.Error, "User was not found");
                    return null!;
                }

                return new SupplierModel()
                {
                    Id = result.Id,
                    CompanyName = result.CompanyName,
                    ContactFName = result.ContactFName,
                    ContactLName = result.ContactLName,
                    ContactTitle = result.ContactTitle,
                    Address1 = result.Address1,
                    Address2 = result.Address2,
                    City = result.City,
                    State = result.State,
                    PostalCode = result.PostalCode,
                    Country = result.Country,
                    Phone = result.Phone,
                    Fax = result.Fax,
                    Email = result.Email,
                    URL = result.URL,
                    PaymentMethods = result.PaymentMethods,
                    DiscountType = result.DiscountType,
                    Notes = result.Notes,
                    DiscountAvailable = result.DiscountAvailable,
                    CurrentOrder = result.CurrentOrder,
                    Logo = result.Logo,
                    CustomerID = result.CustomerID,
                    SizeURL = result.SizeURL
                };
            });
        }

        public async Task<bool> UpdateSupplerAsync(int supplierId, string property, string value)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _supplierRepository.UpdateSupplerAsync(supplierId, property, value);
                if (result == false)
                {
                    _logger.Log(LogLevel.Error, $"An error occured during updating data.");
                }

                return result;
            });
        }
    }
}
