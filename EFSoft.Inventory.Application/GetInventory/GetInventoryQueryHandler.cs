namespace EFSoft.Inventory.Application.GetInventory;

public class GetInventoryQueryHandler(IGetProductInventoryRepository getProductInventory)
    : IQueryHandler<GetInventoryQuery, GetInventoryQueryResult?>
{
    public async Task<GetInventoryQueryResult?> Handle(
            GetInventoryQuery parameters,
            CancellationToken cancellationToken = default)
    {
        var inventory = await getProductInventory.GetProductInventoryAsync(
            parameters.ProductId,
            cancellationToken);


        if (inventory is null)
        {
            return default;
        }

        return new GetInventoryQueryResult(
            ProductId: inventory.ProductId,
            StockLeft: inventory.StockLeft);
    }
}
