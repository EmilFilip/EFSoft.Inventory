namespace EFSoft.Orders.Application.RepositoryContracts;

public interface IInventoryRepository
{
    Task<InventoryModel> GetInventoryAsync(
        Guid productInventory,
        CancellationToken cancellationToken = default);

    Task CreateInventoryAsync(
        InventoryModel inventory,
        CancellationToken cancellationToken = default);

    Task UpdateInventoryAsync(
        InventoryModel inventory,
        CancellationToken cancellationToken = default);
}