namespace EFSoft.Inventory.Application.Commands.UpdateInventory;

public class UpdateInventoryCommand : ICommand
{
    public UpdateInventoryCommand(
         Guid productId,
         int stockLeft)
    {
        ProductId = productId;
        StockLeft = stockLeft;
    }

    public Guid ProductId { get; }
    public int StockLeft { get; }
}
