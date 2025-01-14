namespace EFSoft.Inventory.Application.UpdateInventory;

public sealed record UpdateInventoryCommand(
         Guid ProductId,
         int StockLeft) : ICommand;
