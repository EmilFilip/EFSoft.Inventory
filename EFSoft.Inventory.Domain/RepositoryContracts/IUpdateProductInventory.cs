namespace EFSoft.Inventory.Domain.RepositoryContracts;

public interface IUpdateProductInventory
{
    Task UpdateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default);
}
