using Shop.Data.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<int> AddOrderAsync(
            int customerId,
            int paymentId,
            int shipperId,
            string orderNumber,
            DateTime requiredDate,
            DateTime shipDate,
            string freight,
            DateTime orderDate,
            DateTime paymentDate,
            decimal salesTax,
            DateTime timeStamp,
            bool transactStatus,
            bool paid,
            Dictionary<OrderDetailsModel, ProductModel> orderDetails);
        Task<bool> DeleteOrderAsync(int id);
        Task<bool> UpdateOrderAsync(int id, string property, string value);
        Task<OrderEntity?> GetOrderAsync(int id);
        Task<IEnumerable<OrderEntity?>?> GetOrderByProductIdAsync(int id);
        Task<IEnumerable<OrderEntity>?> GetOrderByPaymentIdAsync(int id);
        Task<IEnumerable<OrderEntity>?> GetOrderByCustomerIdAsync(int id);
        Task<IEnumerable<OrderEntity>?> GetOrderByShipperIdAsync(int id);
    }
}
