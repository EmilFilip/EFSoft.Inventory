namespace EFSoft.Inventory.Application.Commands.CreateInventory;

public class CreateInventoryCommand : ICommand
{
    public CreateInventoryCommand(
         Guid productId,
         int stockLeft)
    {
        ProductId = productId;
        StockLeft = stockLeft;
    }

    public Guid ProductId { get; }
    public int StockLeft { get; }
}
