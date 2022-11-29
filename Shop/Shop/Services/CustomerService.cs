using Microsoft.Extensions.Logging;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Services
{
    public class CustomerService : BaseDataService<ApplicationDBContext>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(
            IDbContextWrapper<ApplicationDBContext> contextWrapper,
            ILogger<BaseDataService<ApplicationDBContext>> baseLogger,
            ICustomerRepository customerRepository,
            ILogger<CustomerService> logger)
            : base(contextWrapper, baseLogger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<int> AddCustomerAsync(
            string firstName,
            string lastName,
            string customerClass,
            string room,
            string building,
            string address1,
            string address2,
            string city,
            string state,
            string postalCode,
            string country,
            string phone,
            string email,
            string voiceMail,
            string password,
            string creditCard,
            int creditCardTypeID,
            string cardExpMo,
            string cardExpYr,
            string billingAddress,
            string billingCity,
            string billingRegion,
            string billingPostalCode,
            string billingCountry,
            string shipAddress,
            string shipCity,
            string shipRegion,
            string shipPostalCode,
            string shipCountry,
            DateTime dateEntered)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _customerRepository.AddCustomerAsync(
                    firstName,
                    lastName,
                    customerClass,
                    room,
                    building,
                    address1,
                    address2,
                    city,
                    state,
                    postalCode,
                    country,
                    phone,
                    email,
                    voiceMail,
                    password,
                    creditCard,
                    creditCardTypeID,
                    cardExpMo,
                    cardExpYr,
                    billingAddress,
                    billingCity,
                    billingRegion,
                    billingPostalCode,
                    billingCountry,
                    shipAddress,
                    shipCity,
                    shipRegion,
                    shipPostalCode,
                    shipCountry,
                    dateEntered);
                _logger.Log(LogLevel.Information, "Customer was sucessfully added");
                return id;
            });
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.DeleteCustomerAsync(id);
                return result;
            });
        }

        public async Task<CustomerModel> GetCustomerAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.GetCustomerAsync(id);

                if (result == null)
                {
                    _logger.Log(LogLevel.Error, "Customer was not found");
                    return null!;
                }

                return new CustomerModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Class = result.Class,
                    Room = result.Room,
                    Building = result.Building,
                    Address1 = result.Address1,
                    Address2 = result.Address2,
                    City = result.City,
                    State = result.State,
                    PostalCode = result.PostalCode,
                    Country = result.Country,
                    Phone = result.Phone,
                    Email = result.Email,
                    VoiceMail = result.VoiceMail,
                    Password = result.Password,
                    CreditCard = result.CreditCard,
                    CreditCardTypeID = result.CreditCardTypeID,
                    CardExpMo = result.CardExpMo,
                    CardExpYr = result.CardExpYr,
                    BillingAddress = result.BillingAddress,
                    BillingCity = result.BillingCity,
                    BillingRegion = result.BillingRegion,
                    BillingPostalCode = result.BillingPostalCode,
                    BillingCountry = result.BillingCountry,
                    ShipAddress = result.ShipAddress,
                    ShipCity = result.ShipCity,
                    ShipRegion = result.ShipRegion,
                    ShipPostalCode = result.ShipPostalCode,
                    ShipCountry = result.ShipCountry,
                    DateEntered = result.DateEntered
                };
            });
        }

        public async Task<bool> UpdateCustomerAsync(int id, string property, string value)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _customerRepository.UpdateCustomerAsync(id, property, value);
                if (result == false)
                {
                    _logger.Log(LogLevel.Error, $"An error occured during updating data.");
                }

                return result;
            });
        }
    }
}
