namespace EFSoft.Inventory.Application.Queries.GetInventory;

public class GetInventoryQuery : IQuery<GetInventoryQueryResult>
{
    public GetInventoryQuery(Guid productId)
    {
        ProductId = productId;
    }

    public Guid ProductId { get; set; }
}
