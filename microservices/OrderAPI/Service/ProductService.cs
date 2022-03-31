using Microsoft.Extensions.Configuration;

using OrderAPI.Models;

using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrderAPI.Service
{
    public class ProductService : IProductService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;
        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }
        public async Task<Product> GetProduct(int productId)
        {
            var requestURL = configuration.GetValue<string>("ProductAPIURL");

            return await httpClient.GetFromJsonAsync<Product>($"{requestURL}/api/product/{productId}");
        }
    }
}
