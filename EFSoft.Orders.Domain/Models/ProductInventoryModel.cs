namespace EFSoft.Orders.Domain.Models;

public class ProductInventoryModel
{
    public ProductInventoryModel(
       Guid productInventoryId,
       Guid productId,
       int stockLeft)
    {
        ProductInventoryId = productInventoryId;
        ProductId = productId;
        StockLeft = stockLeft;
    }
    public ProductInventoryModel(
        Guid productId,
        int stockLeft)
    {
        ProductId = productId;
        StockLeft = stockLeft;
    }

    public static ProductInventoryModel CreateNew(
        Guid productId,
        int stockLeft)
    {
        return new ProductInventoryModel(
            productInventoryId: Guid.NewGuid(),
            productId: productId,
            stockLeft: stockLeft);
    }

    public void DecreaseInventoryStock(
        int productQuantity)
    {
        StockLeft = StockLeft - productQuantity;
    }

    public void IncreaseInventoryStock(
        int productQuantity)
    {
        StockLeft = StockLeft + productQuantity;
    }

    public Guid ProductInventoryId { get; set; }

    public Guid ProductId { get; set; }

    public int StockLeft { get; set; }
}
