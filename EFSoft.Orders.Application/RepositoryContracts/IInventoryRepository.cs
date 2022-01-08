namespace EFSoft.Orders.Application.RepositoryContracts;

public interface IInventoryRepository
{
    Task<ProductInventoryModel> GetProductInventoryAsync(
        Guid productInventory,
        CancellationToken cancellationToken = default);

    Task CreateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default);

    Task UpdateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default);
}