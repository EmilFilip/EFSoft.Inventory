using EFSoft.Inventory.Domain.Models;

namespace EFSoft.Inventory.Domain.RepositoryContracts;

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