using Shop.Data.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface ICustomerService
    {
        Task<int> AddCustomerAsync(
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
            DateTime dateEntered);
        Task<bool> DeleteCustomerAsync(int id);
        Task<bool> UpdateCustomerAsync(int id, string property, string value);
        Task<CustomerModel> GetCustomerAsync(int id);
    }
}
