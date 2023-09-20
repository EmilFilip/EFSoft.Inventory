namespace EFSoft.Inventory.Application.Commands.UpdateInventory;

public class UpdateInventoryCommandHandler : ICommandHandler<UpdateInventoryCommand>
{
    private readonly IInventoryRepository _inventoryRepository;

    public UpdateInventoryCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
    }

    public async Task Handle(
        UpdateInventoryCommand command,
        CancellationToken cancellationToken)
    {
        var inventoryModel = new ProductInventoryModel(
            productId: command.ProductId,
            stockLeft: command.StockLeft);

        await _inventoryRepository.UpdateProductInventoryAsync(inventoryModel);
    }
}