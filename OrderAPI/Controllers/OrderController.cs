using Microsoft.AspNetCore.Mvc;
using OrderAPI.Entities;
using OrderAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository orderRepository;
        public OrderController()
        {
            orderRepository = new OrderRepository();
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = orderRepository.GetOrders();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = orderRepository.GetOrderById(id);
            return Ok(order);
        }
    }
}
