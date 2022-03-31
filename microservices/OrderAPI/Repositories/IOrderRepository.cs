using OrderAPI.Entities;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderAPI.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersByUserName(string userName);
        Task<bool> DeleteAsync(int orderID);
        Task<bool> UpdateAsync(Order order);

        Task<Order> GetByIdAsync(int id);
        Task<Order> AddAsync(Order order);
    }
}
