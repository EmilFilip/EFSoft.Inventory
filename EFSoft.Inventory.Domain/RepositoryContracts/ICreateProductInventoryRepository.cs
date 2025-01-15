namespace EFSoft.Inventory.Domain.RepositoryContracts;

public interface ICreateProductInventoryRepository
{
    Task CreateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default);
}
