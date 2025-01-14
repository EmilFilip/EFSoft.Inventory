[assembly: FunctionsStartup(typeof(EFSoft.Inventory.Stock.Function.Startup))]

namespace EFSoft.Inventory.Stock.Function;

[ExcludeFromCodeCoverage]
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var configuration = builder.GetContext().Configuration;
        _ = builder.Services.RegisterLocalServices(configuration);
        _ = builder.Services.RegisterCqrs(typeof(DecreaseInventoryStockCommand).Assembly);
    }
}
