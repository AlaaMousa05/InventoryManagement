using InventoryManagement.Models;

namespace InventoryManagement.UI;

public static class InventoryUI
{
	public static void DisplayMenu()
	{
		Console.WriteLine();
		Console.WriteLine("=== Inventory Management System ===");
		Console.WriteLine("1. Add Product");
		Console.WriteLine("2. View Products");
		Console.WriteLine("3. Edit Product");
		Console.WriteLine("4. Delete Product");
		Console.WriteLine("5. Search Product");
		Console.WriteLine("6. Exit");
		Console.Write("Choose an option: ");
	}

	public static void DisplayProduct(Product product)
	{
		Console.WriteLine(
			$"Name: {product.Name} | Price: {product.Price} | Quantity: {product.Quantity}");
	}

	public static void DisplayProducts(IEnumerable<Product> products)
	{
		foreach (Product product in products)
		{
			DisplayProduct(product);
		}
	}

	public static void ShowMessage(string message)
	{
		Console.WriteLine(message);
	}

    public static void ShowPrompt(string message)
    {
        Console.Write(message);
    }
}