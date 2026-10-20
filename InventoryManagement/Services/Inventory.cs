using InventoryManagement.Models;

namespace InventoryManagement.Services
{
    public class Inventory
    {
        private readonly List<Product> _products = new();

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

        public bool EditProduct(
            string currentName,
            string newName,
            decimal newPrice,
            int newQuantity)
        {
            Product? product = FindProduct(currentName);

            if (product is null)
            {
                return false;
            }

            product.Update(
                newName,
                newPrice,
                newQuantity);

            return true;
        }


        public bool DeleteProduct(string name)
        {
            Product? product = FindProduct(name);

            if (product is null)
            {
                return false;
            }

            return _products.Remove(product);
        }
    }
}