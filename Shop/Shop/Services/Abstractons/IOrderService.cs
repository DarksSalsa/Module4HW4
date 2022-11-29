using Shop.Data.Entities;

namespace Shop.Repositories.Abstractions
{
    public interface IOrderService
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
        Task<OrderModel> GetOrderAsync(int id);
        Task<IReadOnlyList<OrderModel?>?> GetOrderByProductIdAsync(int id);
        Task<IReadOnlyList<OrderModel>?> GetOrderByPaymentIdAsync(int id);
        Task<IReadOnlyList<OrderModel>?> GetOrderByCustomerIdAsync(int id);
        Task<IReadOnlyList<OrderModel>?> GetOrderByShipperIdAsync(int id);
    }
}
