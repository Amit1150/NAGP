using OrderAPI.Models;

using System.Threading.Tasks;

namespace OrderAPI.Service
{
    public interface IProductService
    {
        Task<Product> GetProduct(int productId);
    }
}
