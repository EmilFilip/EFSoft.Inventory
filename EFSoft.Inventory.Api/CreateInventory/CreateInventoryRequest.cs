namespace EFSoft.Inventory.Api.CreateInventory;

public sealed record CreateInventoryRequest(
         Guid ProductId,
         int StockLeft);
