namespace EFSoft.Inventory.Application.DecreaseInventory;

public sealed record DecreaseInventoryStockCommand(
         Guid ProductId,
         int StockToSubtract) : ICommand;
