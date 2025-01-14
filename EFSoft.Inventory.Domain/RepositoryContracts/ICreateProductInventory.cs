namespace EFSoft.Inventory.Domain.RepositoryContracts;

public interface ICreateProductInventory
{
    Task CreateProductInventoryAsync(
        ProductInventoryModel inventory,
        CancellationToken cancellationToken = default);
}
