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
        InventoryUI.ShowPrompt("Product Name: ");
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
        InventoryUI.ShowPrompt("Product Name: ");
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
        InventoryUI.ShowPrompt("Current Product Name: ");
        string currentName = Console.ReadLine()!;

        InventoryUI.ShowPrompt("New Product Name: ");
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
        InventoryUI.ShowPrompt("Product Name: ");
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

            InventoryUI.ShowPrompt(
                "Invalid choice. Try again: ");
        }
    }

    private static decimal ReadPrice()
    {
        while (true)
        {
            InventoryUI.ShowPrompt("Product Price: ");

            if (decimal.TryParse(
                Console.ReadLine(),
                out decimal price))
            {
                return price;
            }

            InventoryUI.ShowMessage(
                "Invalid price. Please try again.");
        }
    }

    private static int ReadQuantity()
    {
        while (true)
        {
            InventoryUI.ShowPrompt("Product Quantity: ");

            if (int.TryParse(
                Console.ReadLine(),
                out int quantity))
            {
                return quantity;
            }

            InventoryUI.ShowMessage(
                "Invalid quantity. Please try again.");
        }
    }
}