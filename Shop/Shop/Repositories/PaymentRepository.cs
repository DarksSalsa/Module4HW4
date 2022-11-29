using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public PaymentRepository(IDbContextWrapper<ApplicationDBContext> contextWrapper)
        {
            _dbContext = contextWrapper.DbContext;
        }

        public async Task<int> AddPaymentAsync(string paymentType, bool allowed)
        {
            var result = await _dbContext.Payment.AddAsync(new PaymentEntity()
            {
                PaymentType = paymentType,
                Allowed = allowed
            });
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeletePaymentAsync(int id)
        {
            var payment = await GetPaymentAsync(id);
            if (payment != null)
            {
                _dbContext.Payment.Remove(payment);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<PaymentEntity?> GetPaymentAsync(int id)
        {
            return await _dbContext.Payment.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<bool> UpdatePaymentAsync(int id, string property, string value)
        {
            var payment = await GetPaymentAsync(id);

            if (payment != null)
            {
                var changingValue = payment.GetType().GetProperty(property);
                if (changingValue != null)
                {
                    changingValue.SetValue(payment, value, null);
                    _dbContext.Payment.Update(payment);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
