[assembly: FunctionsStartup(typeof(EFSoft.Inventory.Stock.Function.Startup))]

namespace EFSoft.Inventory.Stock.Function;

[ExcludeFromCodeCoverage]
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        IConfiguration configuration = builder.GetContext().Configuration;
        builder.Services.RegisterLocalServices(configuration);
        builder.Services.RegisterCqrs(typeof(DecreaseInventoryStockCommand).Assembly);
    }
}