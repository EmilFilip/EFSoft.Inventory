
using Microsoft.Azure.WebJobs;

namespace EFSoft.Inventory.WebJob
{
    public class Functions
    {
        public async Task ProcessInventoryOrder([ServiceBusTrigger("orderplaced", "InventoryOrderPlaced", Connection = "TopicConnectionString")] string myTopicMessage)
        {
            //_logger.LogInformation($"C# ServiceBus topic trigger function processed message: {myTopicMessage}");

            //var orderPlacedMessage = JsonSerializer.Deserialize<OrderPlaced>(myTopicMessage);

            //var parameters = new DecreaseInventoryStockCommandParameters(
            //    productId: orderPlacedMessage.ProductId,
            //    stockToSubtract: orderPlacedMessage.Quantity);

            //await _commandExecutor.ExecuteAsync(parameters);
        }
    }
}
