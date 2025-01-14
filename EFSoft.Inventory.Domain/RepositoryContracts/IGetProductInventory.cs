namespace EFSoft.Inventory.Domain.RepositoryContracts;

public interface IGetProductInventory
{
    Task<ProductInventoryModel?> GetProductInventoryAsync(
        Guid productInventory,
        CancellationToken cancellationToken = default);
}
