namespace EFSoft.Inventory.Infrastructure.Repositories;

public class GetProductInventory(InventoryDBContext inventoryDbContext) : IGetProductInventory
{
    public async Task<ProductInventoryModel?> GetProductInventoryAsync(
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        var entity = await inventoryDbContext.Inventories
            .AsQueryable()
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.ProductId == productId,
                                cancellationToken: cancellationToken);

        if (entity == null)
        {
            return default;
        }

        return MapToDomain(entity);
    }

    private static ProductInventoryModel MapToDomain(
        ProductInventory entityCustomer)
    {
        return new ProductInventoryModel(
            productInventoryId: entityCustomer.ProductInventoryId,
            productId: entityCustomer.ProductId,
            stockLeft: entityCustomer.StockLeft);
    }
}
