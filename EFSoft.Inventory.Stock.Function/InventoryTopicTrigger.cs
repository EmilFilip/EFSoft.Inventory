namespace EFSoft.InventoryStock.Function
{
    public class InventoryTopicTrigger
    {
        private readonly ICommandExecutor _commandExecutor;
        private readonly ILogger<InventoryTopicTrigger> _logger;

        public InventoryTopicTrigger(
                ICommandExecutor commandExecutor,
                ILogger<InventoryTopicTrigger> log)
        {
            _commandExecutor = commandExecutor
                ?? throw new ArgumentNullException(nameof(commandExecutor));
            _logger = log;
        }

        [FunctionName("InventoryTopicTrigger")]
        public async Task Run([ServiceBusTrigger("orderplaced", "InventoryOrderPlaced", Connection = "TopicConnectionString")] string myTopicMessage)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {myTopicMessage}");

            var orderPlacedMessage = JsonSerializer.Deserialize<OrderPlaced>(myTopicMessage);

            var parameters = new DecreaseInventoryStockCommandParameters(
                productId: orderPlacedMessage.ProductId,
                stockToSubtract: orderPlacedMessage.Quantity);
            
            await _commandExecutor.ExecuteAsync(parameters);
        }
    }
}
