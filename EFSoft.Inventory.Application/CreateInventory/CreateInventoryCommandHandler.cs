namespace EFSoft.Inventory.Application.CreateInventory;

public class CreateInventoryCommandHandler(ICreateProductInventoryRepository createProductInventory)
    : ICommandHandler<CreateInventoryCommand>
{
    public async Task Handle(
        CreateInventoryCommand command,
        CancellationToken cancellationToken)
    {
        var inventoryModel = ProductInventoryModel.CreateNew(
            productId: command.ProductId,
            stockLeft: command.StockLeft);

        await createProductInventory.CreateProductInventoryAsync(
            inventoryModel,
            cancellationToken);
    }
}
