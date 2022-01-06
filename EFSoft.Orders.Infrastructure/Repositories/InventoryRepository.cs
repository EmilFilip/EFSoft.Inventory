namespace EFSoft.Orders.Infrastructure.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDBContext _inventoryDbContext;

    public InventoryRepository(InventoryDBContext inventoryDbContext)
    {
        _inventoryDbContext = inventoryDbContext;
    }

    public async Task<InventoryModel> GetInventoryAsync(
        Guid productInventory,
        CancellationToken cancellationToken = default)
    {
        var entity = await _inventoryDbContext.Inventories.FirstOrDefaultAsync(
            p => p.ProductInventoryId == productInventory,
            cancellationToken: cancellationToken);

        if (entity == null)
        {
            return null;
        }

        return MapToDomain(entity);
    }

    public async Task CreateInventoryAsync(
        InventoryModel inventory,
        CancellationToken cancellationToken = default)
    {
        var entity = MapToEntity(inventory);

        _inventoryDbContext.Inventories.Add(entity);

        await _inventoryDbContext
            .SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateInventoryAsync(
        InventoryModel inventory,
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

    private static InventoryModel MapToDomain(
        ProductInventory entityCustomer)
    {
        return new InventoryModel(
            productInventoryId: entityCustomer.ProductInventoryId,
            productId: entityCustomer.ProductId,
            stockLeft: entityCustomer.StockLeft);
    }

    private static ProductInventory MapToEntity(
        InventoryModel domainCustomer)
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
