namespace EFSoft.Inventory.Application.Commands.Parameters;

public class CreateInventoryCommandParameters : ICommand
{
    public CreateInventoryCommandParameters(
         Guid productId,
         int stockLeft)
    {
        ProductId = productId;
        StockLeft = stockLeft;
    }

    public Guid ProductId { get; }
    public int StockLeft { get; }
}
