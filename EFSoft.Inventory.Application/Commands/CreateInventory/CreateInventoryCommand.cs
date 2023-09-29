namespace EFSoft.Inventory.Application.Commands.CreateInventory;

public sealed record class CreateInventoryCommand(
         Guid ProductId,
         int StockLeft) : ICommand;
