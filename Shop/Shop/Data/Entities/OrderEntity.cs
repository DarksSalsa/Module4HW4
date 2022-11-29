﻿namespace Shop.Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string Freight { get; set; } = null!;
        public decimal SalesTax { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool TransactStatus { get; set; }
        public string? ErrLoc { get; set; }
        public string? ErrMsg { get; set; }
        public bool Fulfilled { get; set; }
        public bool? Deleted { get; set; }
        public bool Paid { get; set; }
        public DateTime PaymentDate { get; set; }
        public int CustomerID { get; set; }
        public CustomerEntity? Customer { get; set; }
        public int PaymentID { get; set; }
        public PaymentEntity? Payment { get; set; }
        public int ShipperID { get; set; }
        public ShipperEntity? Shipper { get; set; }
        public List<OrderDetailsEntity> OrderDetails { get; set; } = new List<OrderDetailsEntity>();
    }
}
