namespace EFSoft.Inventory.Application.Commands.DecreaseInventory;

public class DecreaseInventoryStockCommand : ICommand
{
    public DecreaseInventoryStockCommand(
         Guid productId,
         int stockToSubtract)
    {
        ProductId = productId;
        StockToSubtract = stockToSubtract;
    }

    public Guid ProductId { get; }

    public int StockToSubtract { get; }
}
