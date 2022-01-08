namespace EFSoft.Orders.Application.Commands.Handlers;

public class DecreaseInventoryStockCommandHandler : ICommandHandler<DecreaseInventoryStockCommandParameters>
{
    private readonly IInventoryRepository _inventoryRepository;

    public DecreaseInventoryStockCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
    }

    public async Task HandleAsync(
        DecreaseInventoryStockCommandParameters command)
    {
        var inventoryModel = await _inventoryRepository.GetProductInventoryAsync(
            productInventory: command.ProductId);

        inventoryModel.DecreaseInventoryStock(command.StockToSubtract);

        await _inventoryRepository.UpdateProductInventoryAsync(inventoryModel);
    }
}