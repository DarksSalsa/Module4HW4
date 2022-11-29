using Shop.Data.Entities;
using Shop.Repositories.Abstractions;
using Shop.Services.Abstractons;

namespace Shop
{
    public class App
    {
        private readonly ISupplierService _supplierService;
        private readonly ICategoryService _categoryService;
        private readonly ICustomerService _customerService;
        private readonly IPaymentService _paymentService;
        private readonly IProductService _productService;
        private readonly IShipperService _shipperService;
        private readonly IOrderService _orderService;
        public App(
            ISupplierService supplierService,
            ICategoryService categoryService,
            ICustomerService customerService,
            IPaymentService paymentService,
            IProductService productService,
            IShipperService shipperService,
            IOrderService orderService)
        {
            _supplierService = supplierService;
            _categoryService = categoryService;
            _customerService = customerService;
            _paymentService = paymentService;
            _productService = productService;
            _shipperService = shipperService;
            _orderService = orderService;
        }

        public async Task Run()
        {
            var supplierId1 = await _supplierService.AddSupplierAsync(
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                false,
                "a",
                "a",
                "a",
                "a");
            var supplierId2 = await _supplierService.AddSupplierAsync(
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                "b",
                true,
                "b",
                "b",
                "b",
                "b");

            var categoryid1 = await _categoryService.AddCategoryAsync("c", "c", "c", true);
            var categoryid2 = await _categoryService.AddCategoryAsync("d", "d", "d", false);

            var customerid1 = await _customerService.AddCustomerAsync("e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", 33, "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", "e", DateTime.UtcNow);
            var customerid2 = await _customerService.AddCustomerAsync("f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", 34, "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", "f", DateTime.UtcNow);

            var paymentid1 = await _paymentService.AddPaymentAsync("g", true);
            var paymentid2 = await _paymentService.AddPaymentAsync("h", false);

            var shipperid1 = await _shipperService.AddShipperAsync("i", "i");
            var shipperid2 = await _shipperService.AddShipperAsync("j", "j");

            var productid1 = await _productService.AddProductAsync(supplierId1, categoryid1, "k", "k", 66, "k", "k", 66, 2.5M, "k", "k", "k", "k", "k", 75M, "k", 66, 66, "k", true, true, "k", 66, "k");
            var productid2 = await _productService.AddProductAsync(supplierId1, categoryid1, "l", "l", 67, "l", "l", 67, 3.5M, "l", "l", "l", "l", "l", 25M, "l", 67, 67, "l", false, true, "l", 67, "l");
            var productid3 = await _productService.AddProductAsync(supplierId2, categoryid2, "m", "m", 68, "m", "m", 68, 4.5M, "m", "m", "m", "m", "m", 50M, "m", 68, 68, "m", true, false, "m", 68, "m");
            var productid4 = await _productService.AddProductAsync(supplierId2, categoryid2, "n", "n", 69, "n", "n", 69, 5.5M, "n", "n", "n", "n", "n", 100M, "n", 69, 69, "n", false, false, "n", 69, "n");

            var product1 = await _productService.GetProductAsync(productid1);
            var product2 = await _productService.GetProductAsync(productid2);
            var product3 = await _productService.GetProductAsync(productid3);
            var product4 = await _productService.GetProductAsync(productid4);

            var orderid1 = await _orderService.AddOrderAsync(
                customerid1,
                paymentid1,
                shipperid1,
                "o",
                DateTime.UtcNow,
                DateTime.UtcNow,
                "o",
                DateTime.UtcNow,
                DateTime.UtcNow,
                17M,
                DateTime.UtcNow,
                true,
                true,
                new Dictionary<OrderDetailsModel, ProductModel>()
                {
                    {
                        new OrderDetailsModel()
                        {
                            Quantity = 5,
                            IDSKU = "oo",
                            Fulfilled = true,
                        }, product1!
                    },
                    {
                        new OrderDetailsModel()
                        {
                            Quantity = 10,
                            IDSKU = "ooo",
                            Fulfilled = false,
                        }, product3!
                    }
                });
            var orderid2 = await _orderService.AddOrderAsync(
                customerid2,
                paymentid2,
                shipperid2,
                "p",
                DateTime.UtcNow,
                DateTime.UtcNow,
                "p",
                DateTime.UtcNow,
                DateTime.UtcNow,
                27M,
                DateTime.UtcNow,
                false,
                false,
                new Dictionary<OrderDetailsModel, ProductModel>()
                {
                    {
                        new OrderDetailsModel()
                        {
                            Quantity = 15,
                            IDSKU = "pp",
                            Fulfilled = true,
                        }, product2!
                    },
                    {
                        new OrderDetailsModel()
                        {
                            Quantity = 20,
                            IDSKU = "ppp",
                            Fulfilled = false,
                        }, product4!
                    }
                });
            var result = await _categoryService.GetCategoryAsync(categoryid1);
            var orderByOrderId = await _orderService.GetOrderAsync(orderid1);
            var orderByPayment = await _orderService.GetOrderByPaymentIdAsync(paymentid1);
            var orderByProduct = await _orderService.GetOrderByProductIdAsync(productid3);
            var orderByShipper = await _orderService.GetOrderByShipperIdAsync(shipperid1);
            var orderByCustomer = await _orderService.GetOrderByCustomerIdAsync(customerid1);
            var productByCategory = await _productService.GetProductByCategoryIdAsync(categoryid1);
            var productBySupplier = await _productService.GetProductBySupplierIdAsync(supplierId1);
            foreach (var item in orderByPayment!)
            {
                Console.WriteLine($"Order Number form OrderByPayment : {item!.OrderNumber}");
            }

            foreach (var item in orderByProduct!)
            {
                Console.WriteLine($"Order Number form OrderByProduct : {item!.OrderNumber}");
            }

            foreach (var item in orderByShipper!)
            {
                Console.WriteLine($"Order Number form OrderByShipper : {item!.OrderNumber}");
            }

            foreach (var item in orderByCustomer!)
            {
                Console.WriteLine($"Order Number form OrderByCustomer : {item!.OrderNumber}");
            }

            foreach (var item in productByCategory!)
            {
                Console.WriteLine($"Order Number form OrderByCategory : {item!.ProductName}");
            }

            foreach (var item in productBySupplier!)
            {
                Console.WriteLine($"Order Number form OrderByPayment : {item!.ProductName}");
            }

            var supplierId3 = await _supplierService.AddSupplierAsync(
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                "a",
                false,
                "a",
                "a",
                "a",
                "a");
            var getSupplier = await _supplierService.GetSupplierAsync(supplierId3);

            var deleteResult = await _supplierService.DeleteSupplierAsync(supplierId3);

            var updateResult = await _supplierService.UpdateSupplerAsync(supplierId2, "City", "qqq");
        }
    }
}
