namespace EFSoft.Inventory.Api.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesInstaller
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .AddCqrs(configurator =>
                    configurator.AddHandlers(typeof(GetInventoryQueryParameters).Assembly))
             .AddDbContext<InventoryDBContext>(
                options =>
                {
                    options.UseSqlServer(configuration.GetConnectionString("InventoryConnectionString"), sqlServeroptions =>
                    {
                        sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<IInventoryRepository, InventoryRepository>();
    }
}
