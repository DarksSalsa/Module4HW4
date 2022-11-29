using Shop.Data.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface IPaymentRepository
    {
        Task<int> AddPaymentAsync(string paymentType, bool allowed);
        Task<bool> DeletePaymentAsync(int id);
        Task<bool> UpdatePaymentAsync(int id, string property, string value);
        Task<PaymentEntity?> GetPaymentAsync(int id);
    }
}
