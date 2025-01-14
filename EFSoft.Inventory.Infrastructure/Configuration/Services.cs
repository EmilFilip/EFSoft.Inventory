namespace EFSoft.Inventory.Infrastructure.Configuration;

[ExcludeFromCodeCoverage]
public static class Services
{
    public static IServiceCollection RegisterLocalServices(
                    this IServiceCollection services,
                    IConfiguration configuration)
    {
        return services
             .RegisterCqrs(typeof(CreateInventoryCommand).Assembly)
             .AddDbContext<InventoryDBContext>(
                options =>
                {
                    _ = options.UseSqlServer(configuration.GetConnectionString("InventoryConnectionString"), sqlServeroptions =>
                    {
                        _ = sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<ICreateProductInventory, CreateProductInventory>()
             .AddScoped<IGetProductInventory, GetProductInventory>()
             .AddScoped<IUpdateProductInventory, UpdateProductInventory>();
    }
}
