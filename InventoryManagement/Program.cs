using InventoryManagement.Models;
using InventoryManagement.Services;

Inventory inventory = new();

inventory.AddProduct(
    new Product("Laptop", 1000, 5));

inventory.AddProduct(
    new Product("Mouse", 50, 10));

Console.Write("Enter product to edit: ");
string currentName = Console.ReadLine()!;

Console.Write("Enter new name: ");
string newName = Console.ReadLine()!;

Console.Write("Enter new price: ");
decimal newPrice = decimal.Parse(Console.ReadLine()!);

Console.Write("Enter new quantity: ");
int newQuantity = int.Parse(Console.ReadLine()!);

bool updated = inventory.EditProduct(
    currentName,
    newName,
    newPrice,
    newQuantity);

if (updated)
{
    Console.WriteLine("Product updated successfully!");
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