using InventoryManagement.Models;
using InventoryManagement.Services;

Inventory inventory = new();

inventory.AddProduct(
    new Product("Laptop", 1000, 5));

inventory.AddProduct(
    new Product("Mouse", 50, 10));

Console.Write("Enter product name to search: ");

string productName = Console.ReadLine()!;

Product? product = inventory.FindProduct(productName);

if (product is not null)
{
    Console.WriteLine(
        $"Name: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}");
}
else
{
    Console.WriteLine("Product not found.");
}

Console.ReadKey();