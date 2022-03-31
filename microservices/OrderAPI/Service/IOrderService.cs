using OrderAPI.Entities;

using System.Threading.Tasks;

namespace OrderAPI.Service
{
    public interface IOrderService
    {
        Task CreateOrder(Order order);
    }
}
