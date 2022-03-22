namespace OrderAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderBy { get; set; }
        public int TotalPrice { get; set; }
    }
}
