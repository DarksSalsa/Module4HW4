namespace Shop.Data.Entities
{
    public class ShipperModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public List<OrderModel> Orders { get; set; } = new List<OrderModel>();
    }
}
