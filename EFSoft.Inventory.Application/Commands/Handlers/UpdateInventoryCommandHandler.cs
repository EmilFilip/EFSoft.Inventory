namespace EFSoft.Inventory.Application.Commands.Handlers;

public class UpdateInventoryCommandHandler : ICommandHandler<UpdateInventoryCommandParameters>
{
    private readonly IInventoryRepository _inventoryRepository;

    public UpdateInventoryCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
    }

    public async Task HandleAsync(
        UpdateInventoryCommandParameters command)
    {
        var inventoryModel = new ProductInventoryModel(
            productId: command.ProductId,
            stockLeft: command.StockLeft);

        await _inventoryRepository.UpdateProductInventoryAsync(inventoryModel);
    }
}