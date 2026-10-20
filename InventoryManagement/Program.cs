using InventoryManagement.Services;
using InventoryManagement.UI;

Inventory inventory = new();

InventoryApplication app =
    new InventoryApplication(inventory);

app.Run();