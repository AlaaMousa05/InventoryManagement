using InventoryManagement.Models;
using InventoryManagement.Services;

namespace InventoryManagement.UI;

public class InventoryApplication
{
    private readonly Inventory _inventory;

    public InventoryApplication(Inventory inventory)
    {
        _inventory = inventory;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            InventoryUI.DisplayMenu();

            int choice = ReadChoice();

            switch (choice)
            {
                case 1:
                    AddProduct();
                    break;

                case 2:
                    ViewProducts();
                    break;

                case 3:
                    EditProduct();
                    break;

                case 4:
                    DeleteProduct();
                    break;

                case 5:
                    SearchProduct();
                    break;

                case 6:
                    isRunning = false;
                    InventoryUI.ShowMessage("Goodbye!");
                    break;

                default:
                    InventoryUI.ShowMessage("Invalid choice.");
                    break;
            }
        }
    }

    private void AddProduct()
    {
        Console.Write("Product Name: ");
        string name = Console.ReadLine()!;

        decimal price = ReadPrice();
        int quantity = ReadQuantity();

        Product product = new(
            name,
            price,
            quantity);

        _inventory.AddProduct(product);

        InventoryUI.ShowMessage(
            "Product added successfully.");
    }

    private void ViewProducts()
    {
        IReadOnlyList<Product> products =
            _inventory.GetAllProducts();

        if (!products.Any())
        {
            InventoryUI.ShowMessage(
                "Inventory is empty.");

            return;
        }

        InventoryUI.DisplayProducts(products);
    }

    private void SearchProduct()
    {
        Console.Write("Product Name: ");
        string name = Console.ReadLine()!;

        Product? product =
            _inventory.FindProduct(name);

        if (product is null)
        {
            InventoryUI.ShowMessage(
                "Product not found.");

            return;
        }

        InventoryUI.DisplayProduct(product);
    }

    private void EditProduct()
    {
        Console.Write("Current Product Name: ");
        string currentName = Console.ReadLine()!;

        Console.Write("New Product Name: ");
        string newName = Console.ReadLine()!;

        decimal newPrice = ReadPrice();
        int newQuantity = ReadQuantity();

        bool updated =
            _inventory.EditProduct(
                currentName,
                newName,
                newPrice,
                newQuantity);

        InventoryUI.ShowMessage(
            updated
                ? "Product updated successfully."
                : "Product not found.");
    }

    private void DeleteProduct()
    {
        Console.Write("Product Name: ");
        string name = Console.ReadLine()!;

        bool deleted =
            _inventory.DeleteProduct(name);

        InventoryUI.ShowMessage(
            deleted
                ? "Product deleted successfully."
                : "Product not found.");
    }

    private static int ReadChoice()
    {
        while (true)
        {
            if (int.TryParse(
                Console.ReadLine(),
                out int choice))
            {
                return choice;
            }

            Console.Write("Invalid choice. Try again: ");
        }
    }

    private static decimal ReadPrice()
    {
        while (true)
        {
            Console.Write("Product Price: ");

            if (decimal.TryParse(
                Console.ReadLine(),
                out decimal price))
            {
                return price;
            }

            Console.WriteLine(
                "Invalid price. Please try again.");
        }
    }

    private static int ReadQuantity()
    {
        while (true)
        {
            Console.Write("Product Quantity: ");

            if (int.TryParse(
                Console.ReadLine(),
                out int quantity))
            {
                return quantity;
            }

            Console.WriteLine(
                "Invalid quantity. Please try again.");
        }
    }
}