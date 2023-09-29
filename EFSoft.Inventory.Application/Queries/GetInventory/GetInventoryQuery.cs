namespace EFSoft.Inventory.Application.Queries.GetInventory;

public sealed record class GetInventoryQuery(Guid ProductId) : IQuery<GetInventoryQueryResult>;