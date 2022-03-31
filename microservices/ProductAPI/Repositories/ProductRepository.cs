using ProductAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ProductAPI.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> products;
        public ProductRepository()
        {
            products = new List<Product>
            {
                new Product { Id = 1, Name = "GalaxySamsung", Price = 25000 },
                new Product { Id = 2, Name = "Mobile", Price = 25000 },
                new Product { Id = 3, Name = "Laptop", Price = 80000 },
                new Product { Id = 4, Name = "Headphone", Price = 5000 },
            };
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public Product GetProductById(int id)
        {
            return products.FirstOrDefault(x => x.Id == id);
        }
    }
}
