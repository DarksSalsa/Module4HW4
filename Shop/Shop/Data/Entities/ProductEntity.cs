using System.ComponentModel;

namespace Shop.Data.Entities
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string SKU { get; set; } = null!;
        public string IDSKU { get; set; } = null!;
        public int VendorProductID { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public int QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public string MSRP { get; set; } = null!;
        public string AvailableSize { get; set; } = null!;
        public string AvailableColors { get; set; } = null!;
        public string Size { get; set; } = null!;
        public string Color { get; set; } = null!;
        public decimal Discount { get; set; }
        public string UnitWeight { get; set; } = null!;
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public string ReorderLevel { get; set; } = null!;
        public bool ProductAvailable { get; set; }
        public bool DiscountAvailable { get; set; }
        public string Picture { get; set; } = null!;
        public int Ranking { get; set; }
        public string Note { get; set; } = null!;
        public int SupplierID { get; set; }
        public SupplierEntity? Supplier { get; set; }
        public int CategoryID { get; set; }
        public CategoryEntity? Category { get; set; }
        public List<OrderDetailsEntity> OrderDetails { get; set; } = new List<OrderDetailsEntity>();
    }
}
