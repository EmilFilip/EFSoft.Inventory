namespace EFSoft.Inventory.Application.DecreaseInventory;

public class DecreaseInventoryStockCommandHandler(
    IUpdateProductInventoryRepository updateProductInventory,
    IGetProductInventoryRepository getProductInventory) : ICommandHandler<DecreaseInventoryStockCommand>
{
    public async Task Handle(
        DecreaseInventoryStockCommand command,
        CancellationToken cancellationToken)
    {
        var inventoryModel = await getProductInventory.GetProductInventoryAsync(
            productInventory: command.ProductId,
            cancellationToken: cancellationToken);

        inventoryModel?.DecreaseInventoryStock(command.StockToSubtract);

        await updateProductInventory.UpdateProductInventoryAsync(
            inventory: inventoryModel!,
            cancellationToken: cancellationToken);
    }
}
