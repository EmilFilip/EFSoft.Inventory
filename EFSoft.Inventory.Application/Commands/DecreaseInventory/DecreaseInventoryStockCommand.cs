namespace EFSoft.Inventory.Application.Commands.DecreaseInventory;

public sealed record class DecreaseInventoryStockCommand(
         Guid ProductId,
         int StockToSubtract) : ICommand;