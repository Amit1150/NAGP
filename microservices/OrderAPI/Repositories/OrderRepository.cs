using OrderAPI.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderAPI.Repositories
{
    public class OrderRepository: IOrderRepository
    {
        private readonly List<Order> _orders;
        public OrderRepository()
        {
            _orders = new List<Order>
            {
                new Order { Id = 1, TotalPrice = 20000, UserName = "User1" },
                new Order { Id = 2, TotalPrice = 18000, UserName = "SampleUser" },
                new Order { Id = 3, TotalPrice = 22000, UserName = "User2" },
            };
        }

        public Task<List<Order>> GetOrders()
        {
            return Task.FromResult(_orders);
        }


        public Task<List<Order>> GetOrdersByUserName(string userName)
        {
            var orderList = _orders
                                .Where(o => o.UserName == userName).ToList();
            return Task.FromResult(orderList);
        }

        public Task<bool> UpdateAsync(Order order)
        {
            Order existingOrder = _orders.Where(x => x.Id == order.Id).FirstOrDefault();
            existingOrder = order;
            return Task.FromResult(true);
        }

        public Task<Order> GetByIdAsync(int id)
        {
            return Task.FromResult(_orders.Where(x => x.Id == id).FirstOrDefault());
        }

        public Task<Order> AddAsync(Order order)
        {
            int maxID = _orders.Select(x => x.Id).Max();
            order.Id = maxID + 1;
            _orders.Add(order);
            return Task.FromResult(order);
        }

        public Task<bool> DeleteAsync(int orderID)
        {
            Order order = _orders.Where(x => x.Id == orderID).FirstOrDefault();
            _orders.Remove(order);
            return Task.FromResult(true);
        }
    }
}
