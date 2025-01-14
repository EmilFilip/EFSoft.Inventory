namespace EFSoft.Inventory.Stock.Function;

public class InventoryTopicTrigger(
            IMediator mediator,
            ILogger<InventoryTopicTrigger> logger)
{
    [FunctionName("InventoryTopicTrigger")]
    public async Task Run([ServiceBusTrigger("orderplaced", "InventoryOrderPlaced", Connection = "TopicConnectionString")] string myTopicMessage)
    {
        logger.LogInformation($"ServiceBus topic trigger function processed message: {myTopicMessage}");

        var orderPlacedMessage = JsonSerializer.Deserialize<OrderPlaced>(myTopicMessage);

        var parameters = new DecreaseInventoryStockCommand(
            ProductId: orderPlacedMessage.ProductId,
            StockToSubtract: orderPlacedMessage.Quantity);

        await mediator.Send(parameters);
    }
}
