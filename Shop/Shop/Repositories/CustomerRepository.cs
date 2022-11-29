using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CustomerRepository(IDbContextWrapper<ApplicationDBContext> contextWrapper)
        {
            _dbContext = contextWrapper.DbContext;
        }

        public async Task<int> AddCustomerAsync(string firstName, string lastName, string customerClass, string room, string building, string address1, string address2, string city, string state, string postalCode, string country, string phone, string email, string voiceMail, string password, string creditCard, int creditCardTypeID, string cardExpMo, string cardExpYr, string billingAddress, string billingCity, string billingRegion, string billingPostalCode, string billingCountry, string shipAddress, string shipCity, string shipRegion, string shipPostalCode, string shipCountry, DateTime dateEntered)
        {
            var result = await _dbContext.Customers.AddAsync(new CustomerEntity()
            {
                FirstName = firstName,
                LastName = lastName,
                Class = customerClass,
                Room = room,
                Building = building,
                Address1 = address1,
                Address2 = address2,
                City = city,
                State = state,
                PostalCode = postalCode,
                Country = country,
                Phone = phone,
                Email = email,
                VoiceMail = voiceMail,
                Password = password,
                CreditCard = creditCard,
                CreditCardTypeID = creditCardTypeID,
                CardExpMo = cardExpMo,
                CardExpYr = cardExpYr,
                BillingAddress = billingAddress,
                BillingCity = billingCity,
                BillingRegion = billingRegion,
                BillingPostalCode = billingPostalCode,
                BillingCountry = billingCountry,
                ShipAddress = shipAddress,
                ShipCity = shipCity,
                ShipRegion = shipRegion,
                ShipPostalCode = shipPostalCode,
                ShipCountry = shipCountry,
                DateEntered = dateEntered
            });

            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            var customer = await GetCustomerAsync(id);
            if (customer != null)
            {
                _dbContext.Customers.Remove(customer);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<CustomerEntity?> GetCustomerAsync(int id)
        {
            return await _dbContext.Customers.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> UpdateCustomerAsync(int id, string property, string value)
        {
            var customer = await GetCustomerAsync(id);

            if (customer != null)
            {
                var changingValue = customer.GetType().GetProperty(property);
                if (changingValue != null)
                {
                    changingValue.SetValue(customer, value, null);
                    _dbContext.Customers.Update(customer);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
