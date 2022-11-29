using Microsoft.Extensions.Logging;
using Shop.Data;
using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop.Services
{
    public class OrderService : BaseDataService<ApplicationDBContext>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(
            IDbContextWrapper<ApplicationDBContext> contextWrapper,
            ILogger<BaseDataService<ApplicationDBContext>> baseLogger,
            IOrderRepository orderRepository,
            ILogger<OrderService> logger)
            : base(contextWrapper, baseLogger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
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
            return await ExecuteSafeAsync(async () =>
            {
                var id = await _orderRepository.AddOrderAsync(
                    customerId,
                    paymentId,
                    shipperId,
                    orderNumber,
                    requiredDate,
                    shipDate,
                    freight,
                    orderDate,
                    paymentDate,
                    salesTax,
                    timeStamp,
                    transactStatus,
                    paid,
                    orderDetails);
                _logger.Log(LogLevel.Information, "Order was sucessfully added");
                return id;
            });
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.DeleteOrderAsync(id);
                return result;
            });
        }

        public async Task<OrderModel> GetOrderAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.GetOrderAsync(id);

                if (result == null)
                {
                    _logger.Log(LogLevel.Error, "Order was not found");
                    return null!;
                }

                return new OrderModel()
                {
                    Id = result.Id,
                    CustomerID = result.CustomerID,
                    PaymentID = result.PaymentID,
                    ShipperID = result.ShipperID,
                    RequiredDate = result.RequiredDate,
                    Freight = result.Freight,
                    OrderDate = result.OrderDate,
                    SalesTax = result.SalesTax,
                    TimeStamp = result.TimeStamp,
                    TransactStatus = result.TransactStatus,
                    Paid = result.Paid,
                    OrderDetails = result.OrderDetails.Select(s => new OrderDetailsModel()
                    {
                        OrderNumber = s.OrderNumber,
                        ProductID = s.ProductID,
                        Quantity = s.Quantity,
                        Product = new ProductModel()
                        {
                            Id = s.Product!.Id,
                            SupplierID = s.Product.SupplierID,
                            CategoryID = s.Product.CategoryID,
                            SKU = s.Product.SKU,
                            IDSKU = s.Product.IDSKU,
                            VendorProductID = s.Product.VendorProductID,
                            ProductName = s.Product.ProductName,
                            ProductDescription = s.Product.ProductDescription,
                            QuantityPerUnit = s.Product.QuantityPerUnit,
                            UnitPrice = s.Product.UnitPrice,
                            MSRP = s.Product.MSRP,
                            AvailableSize = s.Product.AvailableSize,
                            AvailableColors = s.Product.AvailableColors,
                            Size = s.Product.Size,
                            Color = s.Product.Color,
                            Discount = s.Product.Discount,
                            UnitWeight = s.Product.UnitWeight,
                            UnitsInStock = s.Product.UnitsInStock,
                            UnitsOnOrder = s.Product.UnitsOnOrder,
                            ReorderLevel = s.Product.ReorderLevel,
                            ProductAvailable = s.Product.ProductAvailable,
                            DiscountAvailable = s.Product.DiscountAvailable,
                            Picture = s.Product.Picture,
                            Ranking = s.Product.Ranking,
                            Note = s.Product.Note,
                        },
                        Price = s.Product.UnitPrice,
                        Discount = s.Product.Discount,
                        Total = s.Product.UnitPrice * s.Quantity * s.Product.Discount / 100,
                        IDSKU = s.IDSKU,
                        Size = s.Product.Size,
                        Color = s.Product.Color,
                        Fulfilled = s.Fulfilled,
                        ShipDate = result.ShipDate,
                        BillDate = result.PaymentDate
                    }).ToList()
                };
            });
        }

        public async Task<IReadOnlyList<OrderModel>?> GetOrderByCustomerIdAsync(int id)
        {
            var data = await _orderRepository.GetOrderByCustomerIdAsync(id);
            if (data == null)
            {
                _logger.Log(LogLevel.Warning, $"For this customer Id = {id} orders were not found.");
                return null!;
            }

            return data.Select(result => new OrderModel()
            {
                Id = result.Id,
                CustomerID = result.CustomerID,
                PaymentID = result.PaymentID,
                ShipperID = result.ShipperID,
                RequiredDate = result.RequiredDate,
                Freight = result.Freight,
                OrderDate = result.OrderDate,
                OrderNumber = result.OrderNumber,
                SalesTax = result.SalesTax,
                TimeStamp = result.TimeStamp,
                TransactStatus = result.TransactStatus,
                Paid = result.Paid,
                OrderDetails = result.OrderDetails.Select(s => new OrderDetailsModel()
                {
                    OrderNumber = s.OrderNumber,
                    ProductID = s.ProductID,
                    Quantity = s.Quantity,
                    Product = new ProductModel()
                    {
                        Id = s.Product!.Id,
                        SupplierID = s.Product!.SupplierID,
                        CategoryID = s.Product!.CategoryID,
                        SKU = s.Product!.SKU,
                        IDSKU = s.Product!.IDSKU,
                        VendorProductID = s.Product!.VendorProductID,
                        ProductName = s.Product!.ProductName,
                        ProductDescription = s.Product!.ProductDescription,
                        QuantityPerUnit = s.Product!.QuantityPerUnit,
                        UnitPrice = s.Product!.UnitPrice,
                        MSRP = s.Product!.MSRP,
                        AvailableSize = s.Product!.AvailableSize,
                        AvailableColors = s.Product!.AvailableColors,
                        Size = s.Product!.Size,
                        Color = s.Product!.Color,
                        Discount = s.Product!.Discount,
                        UnitWeight = s.Product!.UnitWeight,
                        UnitsInStock = s.Product!.UnitsInStock,
                        UnitsOnOrder = s.Product!.UnitsOnOrder,
                        ReorderLevel = s.Product!.ReorderLevel,
                        ProductAvailable = s.Product!.ProductAvailable,
                        DiscountAvailable = s.Product!.DiscountAvailable,
                        Picture = s.Product!.Picture,
                        Ranking = s.Product!.Ranking,
                        Note = s.Product!.Note,
                    },
                    Price = s.Product.UnitPrice,
                    Discount = s.Product.Discount,
                    Total = s.Product.UnitPrice * s.Quantity * s.Product.Discount / 100,
                    IDSKU = s.IDSKU,
                    Size = s.Product.Size,
                    Color = s.Product.Color,
                    Fulfilled = s.Fulfilled,
                    ShipDate = result.ShipDate,
                    BillDate = result.PaymentDate
                }).ToList()
            }).ToList();
        }

        public async Task<IReadOnlyList<OrderModel>?> GetOrderByPaymentIdAsync(int id)
        {
            var data = await _orderRepository.GetOrderByPaymentIdAsync(id);
            if (data == null)
            {
                _logger.Log(LogLevel.Warning, $"For this payment Id = {id} orders were not found.");
                return null;
            }

            return data.Select(result => new OrderModel()
            {
                Id = result.Id,
                CustomerID = result.CustomerID,
                PaymentID = result.PaymentID,
                ShipperID = result.ShipperID,
                RequiredDate = result.RequiredDate,
                Freight = result.Freight,
                OrderDate = result.OrderDate,
                OrderNumber = result.OrderNumber,
                SalesTax = result.SalesTax,
                TimeStamp = result.TimeStamp,
                TransactStatus = result.TransactStatus,
                Paid = result.Paid,
                OrderDetails = result.OrderDetails.Select(s => new OrderDetailsModel()
                {
                    OrderNumber = s.OrderNumber,
                    ProductID = s.ProductID,
                    Quantity = s.Quantity,
                    Product = new ProductModel()
                    {
                        Id = s.Product!.Id,
                        SupplierID = s.Product.SupplierID,
                        CategoryID = s.Product.CategoryID,
                        SKU = s.Product.SKU,
                        IDSKU = s.Product.IDSKU,
                        VendorProductID = s.Product.VendorProductID,
                        ProductName = s.Product.ProductName,
                        ProductDescription = s.Product.ProductDescription,
                        QuantityPerUnit = s.Product.QuantityPerUnit,
                        UnitPrice = s.Product.UnitPrice,
                        MSRP = s.Product.MSRP,
                        AvailableSize = s.Product.AvailableSize,
                        AvailableColors = s.Product.AvailableColors,
                        Size = s.Product.Size,
                        Color = s.Product.Color,
                        Discount = s.Product.Discount,
                        UnitWeight = s.Product.UnitWeight,
                        UnitsInStock = s.Product.UnitsInStock,
                        UnitsOnOrder = s.Product.UnitsOnOrder,
                        ReorderLevel = s.Product.ReorderLevel,
                        ProductAvailable = s.Product.ProductAvailable,
                        DiscountAvailable = s.Product.DiscountAvailable,
                        Picture = s.Product.Picture,
                        Ranking = s.Product.Ranking,
                        Note = s.Product.Note,
                    },
                    Price = s.Product.UnitPrice,
                    Discount = s.Product.Discount,
                    Total = s.Product.UnitPrice * s.Quantity * s.Product.Discount / 100,
                    IDSKU = s.IDSKU,
                    Size = s.Product.Size,
                    Color = s.Product.Color,
                    Fulfilled = s.Fulfilled,
                    ShipDate = result.ShipDate,
                    BillDate = result.PaymentDate
                }).ToList()
            }).ToList();
        }

        public async Task<IReadOnlyList<OrderModel?>?> GetOrderByProductIdAsync(int id)
        {
            var data = await _orderRepository.GetOrderByProductIdAsync(id);
            if (data == null)
            {
                _logger.Log(LogLevel.Warning, $"For this customer Id = {id} orders were not found.");
                return null;
            }

            foreach (var item in data!)
            {
                if (item == null)
                {
                    _logger.Log(LogLevel.Warning, $"For this customer Id = {id} orders were not found.");
                    return null;
                }
            }

            return data!.Select(result => new OrderModel()
            {
                Id = result!.Id,
                CustomerID = result!.CustomerID,
                PaymentID = result!.PaymentID,
                ShipperID = result!.ShipperID,
                RequiredDate = result!.RequiredDate,
                Freight = result!.Freight,
                OrderDate = result!.OrderDate,
                OrderNumber = result.OrderNumber,
                SalesTax = result!.SalesTax,
                TimeStamp = result!.TimeStamp,
                TransactStatus = result!.TransactStatus,
                Paid = result!.Paid,
                OrderDetails = result!.OrderDetails.Select(s => new OrderDetailsModel()
                {
                    OrderNumber = s.OrderNumber,
                    ProductID = s.ProductID,
                    Quantity = s.Quantity,
                    Product = new ProductModel()
                    {
                        Id = s.Product!.Id,
                        SupplierID = s.Product.SupplierID,
                        CategoryID = s.Product.CategoryID,
                        SKU = s.Product.SKU,
                        IDSKU = s.Product.IDSKU,
                        VendorProductID = s.Product.VendorProductID,
                        ProductName = s.Product.ProductName,
                        ProductDescription = s.Product.ProductDescription,
                        QuantityPerUnit = s.Product.QuantityPerUnit,
                        UnitPrice = s.Product.UnitPrice,
                        MSRP = s.Product.MSRP,
                        AvailableSize = s.Product.AvailableSize,
                        AvailableColors = s.Product.AvailableColors,
                        Size = s.Product.Size,
                        Color = s.Product.Color,
                        Discount = s.Product.Discount,
                        UnitWeight = s.Product.UnitWeight,
                        UnitsInStock = s.Product.UnitsInStock,
                        UnitsOnOrder = s.Product.UnitsOnOrder,
                        ReorderLevel = s.Product.ReorderLevel,
                        ProductAvailable = s.Product.ProductAvailable,
                        DiscountAvailable = s.Product.DiscountAvailable,
                        Picture = s.Product.Picture,
                        Ranking = s.Product.Ranking,
                        Note = s.Product.Note,
                    },
                    Price = s.Product.UnitPrice,
                    Discount = s.Product.Discount,
                    Total = s.Product.UnitPrice * s.Quantity * s.Product.Discount / 100,
                    IDSKU = s.IDSKU,
                    Size = s.Product.Size,
                    Color = s.Product.Color,
                    Fulfilled = s.Fulfilled,
                    ShipDate = result.ShipDate,
                    BillDate = result.PaymentDate
                }).ToList()
            }).ToList();
        }

        public async Task<IReadOnlyList<OrderModel>?> GetOrderByShipperIdAsync(int id)
        {
            var data = await _orderRepository.GetOrderByShipperIdAsync(id);
            if (data == null)
            {
                _logger.Log(LogLevel.Warning, $"For this shipper Id = {id} orders were not found.");
                return null;
            }

            return data.Select(result => new OrderModel()
            {
                Id = result.Id,
                CustomerID = result.CustomerID,
                PaymentID = result.PaymentID,
                ShipperID = result.ShipperID,
                RequiredDate = result.RequiredDate,
                Freight = result.Freight,
                OrderDate = result.OrderDate,
                OrderNumber = result.OrderNumber,
                SalesTax = result.SalesTax,
                TimeStamp = result.TimeStamp,
                TransactStatus = result.TransactStatus,
                Paid = result.Paid,
                OrderDetails = result.OrderDetails.Select(s => new OrderDetailsModel()
                {
                    OrderNumber = s.OrderNumber,
                    ProductID = s.ProductID,
                    Quantity = s.Quantity,
                    Product = new ProductModel()
                    {
                        Id = s.Product!.Id,
                        SupplierID = s.Product.SupplierID,
                        CategoryID = s.Product.CategoryID,
                        SKU = s.Product.SKU,
                        IDSKU = s.Product.IDSKU,
                        VendorProductID = s.Product.VendorProductID,
                        ProductName = s.Product.ProductName,
                        ProductDescription = s.Product.ProductDescription,
                        QuantityPerUnit = s.Product.QuantityPerUnit,
                        UnitPrice = s.Product.UnitPrice,
                        MSRP = s.Product.MSRP,
                        AvailableSize = s.Product.AvailableSize,
                        AvailableColors = s.Product.AvailableColors,
                        Size = s.Product.Size,
                        Color = s.Product.Color,
                        Discount = s.Product.Discount,
                        UnitWeight = s.Product.UnitWeight,
                        UnitsInStock = s.Product.UnitsInStock,
                        UnitsOnOrder = s.Product.UnitsOnOrder,
                        ReorderLevel = s.Product.ReorderLevel,
                        ProductAvailable = s.Product.ProductAvailable,
                        DiscountAvailable = s.Product.DiscountAvailable,
                        Picture = s.Product.Picture,
                        Ranking = s.Product.Ranking,
                        Note = s.Product.Note,
                    },
                    Price = s.Product.UnitPrice,
                    Discount = s.Product.Discount,
                    Total = s.Product.UnitPrice * s.Quantity * s.Product.Discount / 100,
                    IDSKU = s.IDSKU,
                    Size = s.Product.Size,
                    Color = s.Product.Color,
                    Fulfilled = s.Fulfilled,
                    ShipDate = result.ShipDate,
                    BillDate = result.PaymentDate
                }).ToList()
            }).ToList();
        }

        public async Task<bool> UpdateOrderAsync(int id, string property, string value)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var result = await _orderRepository.UpdateOrderAsync(id, property, value);
                if (result == false)
                {
                    _logger.Log(LogLevel.Error, $"An error occured during updating data.");
                }

                return result;
            });
        }
    }
}
