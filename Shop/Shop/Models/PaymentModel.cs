namespace Shop.Data.Entities
{
    public class PaymentModel
    {
        public int Id { get; set; }
        public string PaymentType { get; set; } = null!;
        public bool Allowed { get; set; }
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
