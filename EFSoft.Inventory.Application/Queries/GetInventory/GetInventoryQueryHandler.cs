namespace EFSoft.Inventory.Application.Queries.GetInventory;

public class GetInventoryQueryHandler : IQueryHandler<GetInventoryQuery, GetInventoryQueryResult>
{
    private readonly IInventoryRepository _inventoryRepository;

    public GetInventoryQueryHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task<GetInventoryQueryResult> Handle(
            GetInventoryQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var inventory = await _inventoryRepository.GetProductInventoryAsync(
            parameters.ProductId,
            cancellationToken);


        if (inventory is null)
        {
            return null;
        }


        return new GetInventoryQueryResult(
            productId: inventory.ProductId,
            stockLeft: inventory.StockLeft);
    }
}
