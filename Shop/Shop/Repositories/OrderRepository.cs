using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public OrderRepository(IDbContextWrapper<ApplicationDBContext> contextWrapper)
        {
            _dbContext = contextWrapper.DbContext;
        }

        public async Task<int> AddOrderAsync(
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
            Dictionary<OrderDetailsModel, ProductModel> orderDetails)
        {
            var result = await _dbContext.Orders.AddAsync(new OrderEntity()
            {
                CustomerID = customerId,
                PaymentID = paymentId,
                ShipperID = shipperId,
                OrderNumber = orderNumber,
                RequiredDate = requiredDate,
                Freight = freight,
                OrderDate = orderDate,
                PaymentDate = paymentDate,
                ShipDate = shipDate,
                SalesTax = salesTax,
                TimeStamp = timeStamp,
                TransactStatus = transactStatus,
                Paid = paid,
            });

            await _dbContext.OrderDetails.AddRangeAsync(orderDetails.Select(s => new OrderDetailsEntity()
            {
                OrderID = result.Entity.Id,
                ProductID = s.Value.Id,
                OrderNumber = result.Entity.OrderNumber,
                Price = s.Value.UnitPrice,
                Quantity = s.Key.Quantity,
                Discount = s.Value.Discount,
                Total = s.Key.Quantity * s.Value.UnitPrice * s.Value.Discount / 100,
                IDSKU = s.Key.IDSKU,
                Size = s.Value.Size,
                Color = s.Value.Color,
                Fulfilled = s.Key.Fulfilled,
                ShipDate = result.Entity.ShipDate,
                BillDate = result.Entity.PaymentDate,
            }));
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await GetOrderAsync(id);
            if (order != null)
            {
                _dbContext.Orders.Remove(order);
                await _dbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<OrderEntity?> GetOrderAsync(int id)
        {
            return await _dbContext.Orders.Include(i => i.OrderDetails).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<OrderEntity>?> GetOrderByCustomerIdAsync(int id)
        {
            return await _dbContext.Orders.Include(i => i.OrderDetails).Where(w => w.CustomerID == id).ToListAsync();
        }

        public async Task<IEnumerable<OrderEntity>?> GetOrderByPaymentIdAsync(int id)
        {
            return await _dbContext.Orders.Include(i => i.OrderDetails).Where(w => w.PaymentID == id).ToListAsync();
        }

        public async Task<IEnumerable<OrderEntity?>?> GetOrderByProductIdAsync(int id)
        {
            var innerListOfOrderDetails = await _dbContext.Orders.Include(i => i.OrderDetails)
                .SelectMany(s => s.OrderDetails.Where(w => w.ProductID == id)).ToListAsync();
            return innerListOfOrderDetails.Select(s => s.Order).ToList();
        }

        public async Task<IEnumerable<OrderEntity>?> GetOrderByShipperIdAsync(int id)
        {
            return await _dbContext.Orders.Include(i => i.OrderDetails).Where(w => w.ShipperID == id).ToListAsync();
        }

        public async Task<bool> UpdateOrderAsync(int id, string property, string value)
        {
            var order = await GetOrderAsync(id);

            if (order != null)
            {
                var changingValue = order.GetType().GetProperty(property);
                if (changingValue != null)
                {
                    changingValue.SetValue(order, value, null);
                    _dbContext.Orders.Update(order);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
    }
}
