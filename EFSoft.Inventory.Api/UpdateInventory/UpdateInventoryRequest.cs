namespace EFSoft.Inventory.Api.UpdateInventory;

public sealed record UpdateInventoryRequest(
         Guid ProductId,
         int StockLeft);
