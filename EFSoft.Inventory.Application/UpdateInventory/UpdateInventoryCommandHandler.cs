namespace EFSoft.Inventory.Application.UpdateInventory;

public class UpdateInventoryCommandHandler(IUpdateProductInventoryRepository updateProductInventory)
    : ICommandHandler<UpdateInventoryCommand>
{
    public async Task Handle(
        UpdateInventoryCommand command,
        CancellationToken cancellationToken)
    {
        var inventoryModel = new ProductInventoryModel(
            productId: command.ProductId,
            stockLeft: command.StockLeft);

        await updateProductInventory.UpdateProductInventoryAsync(
            inventoryModel,
            cancellationToken);
    }
}
