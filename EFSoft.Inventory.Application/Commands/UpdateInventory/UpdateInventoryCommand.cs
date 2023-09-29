namespace EFSoft.Inventory.Application.Commands.UpdateInventory;

public sealed record class UpdateInventoryCommand(
         Guid ProductId,
         int StockLeft) : ICommand;