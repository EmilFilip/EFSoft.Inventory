namespace EFSoft.Inventory.Application.Commands.CreateInventory;

public class CreateInventoryCommandHandler : ICommandHandler<CreateInventoryCommand>
{
    private readonly IInventoryRepository _inventoryRepository;

    public CreateInventoryCommandHandler(IInventoryRepository inventoryRepository)
    {
        _inventoryRepository = inventoryRepository;
    }

    public async Task Handle(
        CreateInventoryCommand command,
        CancellationToken cancellationToken)
    {
        var inventoryModel = ProductInventoryModel.CreateNew(
            productId: command.ProductId,
            stockLeft: command.StockLeft);

        await _inventoryRepository.CreateProductInventoryAsync(inventoryModel);
    }
}
