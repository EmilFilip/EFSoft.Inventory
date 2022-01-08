namespace EFSoft.Inventory.Application.Commands.Handlers;

public class CreateInventoryCommandHandler : ICommandHandler<CreateInventoryCommandParameters>
{
    private readonly IInventoryRepository _inventoryRepository;

    public CreateInventoryCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository ?? throw new ArgumentNullException(nameof(inventoryRepository));
    }

    public async Task HandleAsync(
        CreateInventoryCommandParameters command)
    {
        var inventoryModel = ProductInventoryModel.CreateNew(
            productId: command.ProductId,
            stockLeft: command.StockLeft);

        await _inventoryRepository.CreateProductInventoryAsync(inventoryModel);
    }
}
