namespace EFSoft.Orders.Application.Commands.Handlers;

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
        var inventoryModel = new InventoryModel(
            productId: command.ProductId,
            stockLeft: command.StockLeft);

        await _inventoryRepository.UpdateInventoryAsync(inventoryModel);
    }
}