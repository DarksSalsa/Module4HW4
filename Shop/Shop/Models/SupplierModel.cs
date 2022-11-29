namespace Shop.Data.Entities
{
    public class SupplierModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string ContactFName { get; set; } = null!;
        public string ContactLName { get; set; } = null!;
        public string ContactTitle { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Fax { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string URL { get; set; } = null!;
        public string PaymentMethods { get; set; } = null!;
        public string DiscountType { get; set; } = null!;
        public string Notes { get; set; } = null!;
        public bool DiscountAvailable { get; set; }
        public string CurrentOrder { get; set; } = null!;
        public string Logo { get; set; } = null!;
        public string CustomerID { get; set; }
        public string SizeURL { get; set; } = null!;
        public List<ProductModel> TypeGoods { get; set; } = new List<ProductModel>();
    }
}
