namespace EFSoft.Orders.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDBContext _inventoryDbContext;

    public InventoryRepository(InventoryDBContext inventoryDbContext)
    {
        _inventoryDbContext = inventoryDbContext;
    }

    public async Task<ProductInventoryModel> GetProductInventoryAsync(
        Guid productId,
        CancellationToken cancellationToken = default)
    {
        var entity = await _inventoryDbContext.Inventories.FirstOrDefaultAsync(
            p => p.ProductId == productId,
            cancellationToken: cancellationToken);

        if (entity == null)
        {
            return null;
        }

        return MapToDomain(entity);
    }

    public async Task CreateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(inventory);

        _inventoryDbContext.Inventories.Add(entity);

        await _inventoryDbContext
            .SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default)
    {
        var entity = await _inventoryDbContext.Inventories.FindAsync(
            keyValues: new object[] { inventory.ProductInventoryId },
            cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.StockLeft = inventory.StockLeft;

            _inventoryDbContext.Update(entity);
            await _inventoryDbContext.SaveChangesAsync(cancellationToken);
        }
    }

    private static ProductInventoryModel MapToDomain(
        ProductInventory entityCustomer)
    {
        return new ProductInventoryModel(
            productInventoryId: entityCustomer.ProductInventoryId,
            productId: entityCustomer.ProductId,
            stockLeft: entityCustomer.StockLeft);
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
