namespace EFSoft.Inventory.Application.GetInventory;

public sealed record GetInventoryQuery(Guid ProductId) : IQuery<GetInventoryQueryResult>;
