namespace EFSoft.Inventory.Application.GetInventory;

public sealed record GetInventoryQueryResult(
        Guid ProductId,
        int StockLeft);
