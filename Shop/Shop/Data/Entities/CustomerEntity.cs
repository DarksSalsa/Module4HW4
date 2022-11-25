namespace Shop.Data.Entities
{
    public class CustomerEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Class { get; set; } = null!;
        public string Room { get; set; } = null!;
        public string Building { get; set; } = null!;
        public string Address1 { get; set; } = null!;
        public string Address2 { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? VoiceMail { get; set; }
        public string Password { get; set; } = null!;
        public string CreditCard { get; set; } = null!;
        public int CreditCardTypeID { get; set; }
        public string CardExpMo { get; set; } = null!;
        public string CardExpYr { get; set; } = null!;
        public string BillingAddress { get; set; } = null!;
        public string BillingCity { get; set; } = null!;
        public string BillingRegion { get; set; } = null!;
        public string BillingPostalCode { get; set; } = null!;
        public string BillingCountry { get; set; } = null!;
        public string ShipAddress { get; set; } = null!;
        public string ShipCity { get; set; } = null!;
        public string ShipRegion { get; set; } = null!;
        public string ShipPostalCode { get; set; } = null!;
        public string ShipCountry { get; set; } = null!;
        public DateTime DateEntered { get; set; }
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
