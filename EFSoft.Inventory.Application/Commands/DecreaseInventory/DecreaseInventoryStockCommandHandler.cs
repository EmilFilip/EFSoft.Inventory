namespace EFSoft.Inventory.Application.Commands.DecreaseInventory;

public class DecreaseInventoryStockCommandHandler : ICommandHandler<DecreaseInventoryStockCommand>
{
    private readonly IInventoryRepository _inventoryRepository;

    public DecreaseInventoryStockCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task Handle(
        DecreaseInventoryStockCommand command,
        CancellationToken cancellationToken)
    {
        var inventoryModel = await _inventoryRepository.GetProductInventoryAsync(
            productInventory: command.ProductId);

        inventoryModel.DecreaseInventoryStock(command.StockToSubtract);

        await _inventoryRepository.UpdateProductInventoryAsync(inventoryModel);
    }
}