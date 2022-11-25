namespace Shop.Data.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public string PaymentType { get; set; } = null!;
        public bool Allowed { get; set; }
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
