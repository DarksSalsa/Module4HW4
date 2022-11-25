namespace Shop.Data.Entities
{
    public class OrderDetailsEntity
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = null!;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public string IDSKU { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public bool Fulfilled { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime BillDate { get; set; }
        public int OrderID { get; set; }
        public OrderEntity Order { get; set; } = null!;
        public int ProductID { get; set; }
        public ProductEntitiy Product { get; set; } = null!;
    }
}
