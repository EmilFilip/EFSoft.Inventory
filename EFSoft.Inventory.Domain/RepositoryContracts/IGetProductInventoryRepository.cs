namespace EFSoft.Inventory.Domain.RepositoryContracts;

public interface IGetProductInventoryRepository
{
    Task<ProductInventoryModel?> GetProductInventoryAsync(
        Guid productInventory,
        CancellationToken cancellationToken = default);
}
