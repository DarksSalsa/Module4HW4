namespace Shop.Data.Entities
{
    public class ShipperEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();
    }
}
