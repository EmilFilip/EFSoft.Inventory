namespace EFSoft.InventoryStock.Function;

public class InventoryTopicTrigger
{
    private readonly IMediator _mediator;
    private readonly ILogger<InventoryTopicTrigger> _logger;

    public InventoryTopicTrigger(
            IMediator commandExecutor,
            ILogger<InventoryTopicTrigger> logger)
    {
        _mediator = commandExecutor;
        _logger = logger;
    }

    [FunctionName("InventoryTopicTrigger")]
    public async Task Run([ServiceBusTrigger("orderplaced", "InventoryOrderPlaced", Connection = "TopicConnectionString")] string myTopicMessage)
    {
        _logger.LogInformation($"ServiceBus topic trigger function processed message: {myTopicMessage}");

        var orderPlacedMessage = JsonSerializer.Deserialize<OrderPlaced>(myTopicMessage);

        var parameters = new DecreaseInventoryStockCommand(
            ProductId: orderPlacedMessage.ProductId,
            StockToSubtract: orderPlacedMessage.Quantity);
        
        await _mediator.Send(parameters);
    }
}
