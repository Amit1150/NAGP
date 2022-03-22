using OrderAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderAPI.Repositories
{
    public class OrderRepository
    {
        private readonly List<Order> orders;
        public OrderRepository()
        {
            orders = new List<Order>
            {
                new Order { Id = 1, TotalPrice = 20000, OrderBy = "User1" },
                new Order { Id = 2, TotalPrice = 18000, OrderBy = "SampleUser" },
                new Order { Id = 3, TotalPrice = 22000, OrderBy = "User2" },
            };
        }

        public List<Order> GetOrders()
        {
            return orders;
        }

        public Order GetOrderById(int id)
        {
            return orders.FirstOrDefault(x => x.Id == id);
        }
    }
}
