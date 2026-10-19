using InventoryManagement.Models;
using InventoryManagement.Services;

Inventory inventory = new();

Console.Write("Enter product name: ");
string name = Console.ReadLine()!;

Console.Write("Enter product price: ");
decimal price = decimal.Parse(Console.ReadLine()!);

Console.Write("Enter product quantity: ");
int quantity = int.Parse(Console.ReadLine()!);

Product product = new(name, price, quantity);

inventory.AddProduct(product);

Console.WriteLine($"Product {product.Name} added successfully!");


Console.WriteLine("\nInventory Products:");

foreach (Product item in inventory.GetAllProducts())
{
    Console.WriteLine(
        $"Name: {item.Name} | Price: {item.Price} | Quantity: {item.Quantity}");
}



Console.ReadKey();
