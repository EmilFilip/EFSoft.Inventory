namespace EFSoft.Inventory.Application.CreateInventory;

public sealed record CreateInventoryCommand(
         Guid ProductId,
         int StockLeft) : ICommand;
