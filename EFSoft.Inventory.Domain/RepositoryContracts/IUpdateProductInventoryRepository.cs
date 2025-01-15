namespace EFSoft.Inventory.Domain.RepositoryContracts;

public interface IUpdateProductInventoryRepository
{
    Task UpdateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default);
}
