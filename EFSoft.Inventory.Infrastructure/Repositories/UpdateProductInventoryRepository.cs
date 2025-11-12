namespace EFSoft.Inventory.Infrastructure.Repositories;

public class UpdateProductInventoryRepository(InventoryDBContext inventoryDbContext) : IUpdateProductInventoryRepository
{
    public async Task UpdateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default)
    {
        var entity = await inventoryDbContext.Inventories
            .AsQueryable()
            .FirstOrDefaultAsync(p => p.ProductId == inventory.ProductId,
                                cancellationToken: cancellationToken);

        if (entity != null)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            entity.StockLeft = inventory.StockLeft;

            _ = inventoryDbContext.Update(entity);
            _ = await inventoryDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
