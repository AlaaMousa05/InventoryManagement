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
    }
}