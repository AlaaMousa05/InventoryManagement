using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class Inventory
    {
        private readonly List<Product> _products = new List<Product>();


        public void AddProduct(Product product)
        {
            _products.Add(product);
        }


        public List<Product> GetAllProducts()
        {
            return _products;
        }



        public Product? FindProduct(string name)
        {
            return _products.FirstOrDefault(
                p => p.Name.Equals(
                    name,
                    StringComparison.OrdinalIgnoreCase));
        }


    }
}