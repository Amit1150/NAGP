using OrderAPI.Entities;
using OrderAPI.Repositories;

using System.Threading.Tasks;

namespace OrderAPI.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        public OrderService(IProductService productService)
        {
            _productService = productService;
            _orderRepository = new OrderRepository();
        }

        public async Task CreateOrder(Order order)
        {
            var product = await _productService.GetProduct(order.ProductId);
            if(product != null && product.Id > 0)
            {
                await _orderRepository.AddAsync(order);
            }
            else
            {
                throw new System.Exception("Product does not exists");
            }
        }
    }
}
