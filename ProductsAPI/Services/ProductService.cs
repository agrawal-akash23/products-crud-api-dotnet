using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class ProductService : IProductService
    {
        // In-memory list - acts as our "database" for now
        // Project 4 replaces this with the real SQL Server
        private readonly List<Product> _products = new()
        {
            new Product{Id = 1, Name = "Laptop", Category = "Electronics", Price = 75000, StockQuantity = 10, CreatedAt = DateTime.UtcNow.AddDays(-30)},
            new Product{Id = 2, Name = "Desk Chair", Category = "Furniture", Price = 12000, StockQuantity = 25, CreatedAt = DateTime.UtcNow.AddDays(-15)},
            new Product{Id = 3, Name = "Notebook", Category = "Stationary", Price = 120, StockQuantity = 120, CreatedAt = DateTime.UtcNow.AddDays(-5)},
        };

        private int _nextId = 4;

        public List<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public Product Add(Product product)
        {
            product.Id = _nextId++;  // Stimulates auto-increment IDs like SQL Server's IDENTITY column.
            product.CreatedAt = DateTime.UtcNow;
            _products.Add(product);
            return product;
        }
        public Product? Update(int id, Product updated)
        {
            var existing = _products.FirstOrDefault(x => x.Id == id);
            if (existing == null) return null;

            existing.Name = updated.Name;
            existing.Category = updated.Category;
            existing.Price = updated.Price;
            existing.StockQuantity = updated.StockQuantity;

            return existing;
        }
        public bool Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            _products.Remove(product);
            return true;
        }
    }
}
