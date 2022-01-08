namespace EFSoft.Inventory.Application.Queries.Handlers;

public class GetInventoryQueryHandler :
        IQueryHandler<GetInventoryQueryParameters, GetInventoryQueryResult>
{
    private readonly IInventoryRepository _inventoryRepository;

    public GetInventoryQueryHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
    }

    public async Task<GetInventoryQueryResult> HandleAsync(
            GetInventoryQueryParameters parameters,
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
