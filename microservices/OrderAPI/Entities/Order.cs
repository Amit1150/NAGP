namespace OrderAPI.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int TotalPrice { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
    }
}
