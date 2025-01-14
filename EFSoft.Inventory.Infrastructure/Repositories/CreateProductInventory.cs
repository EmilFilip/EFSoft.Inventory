namespace EFSoft.Inventory.Infrastructure.Repositories;

public class CreateProductInventory(InventoryDBContext inventoryDbContext) : ICreateProductInventory
{
    public async Task CreateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(inventory);

        _ = inventoryDbContext.Inventories.Add(entity);

        _ = await inventoryDbContext
            .SaveChangesAsync(cancellationToken);
    }

    private static ProductInventory MapToEntity(
        ProductInventoryModel domainCustomer)
    {
        return new ProductInventory
        {
            ProductInventoryId = domainCustomer.ProductInventoryId,
            ProductId = domainCustomer.ProductId,
            StockLeft = domainCustomer.StockLeft,
            UpdatedAt = DateTime.UtcNow
        };
    }
}
