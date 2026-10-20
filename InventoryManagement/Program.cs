using InventoryManagement.Models;
using InventoryManagement.Services;

Inventory inventory = new();

inventory.AddProduct(
    new Product("Laptop", 1000, 5));

inventory.AddProduct(
    new Product("Mouse", 50, 10));

Console.Write("Enter product name to delete: ");

string productName = Console.ReadLine()!;

bool deleted = inventory.DeleteProduct(productName);

if (deleted)
{
    Console.WriteLine("Product deleted successfully!");
}
else
{
    Console.WriteLine("Product not found.");
}

Console.WriteLine("\nCurrent Products:");

foreach (Product item in inventory.GetAllProducts())
{
    Console.WriteLine(
        $"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
}

Console.ReadKey();