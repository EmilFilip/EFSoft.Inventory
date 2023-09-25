using EFSoft.Inventory.Application.Commands.CreateInventory;
using EFSoft.Shared.Cqrs.Configuration;

namespace EFSoft.Inventory.Infrastructure.Configuration;

[ExcludeFromCodeCoverage]
public static class ServicesInstaller
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
                    options.UseSqlServer(configuration.GetConnectionString("InventoryConnectionString"), sqlServeroptions =>
                    {
                        sqlServeroptions.EnableRetryOnFailure();
                    });
                })
             .AddScoped<IInventoryRepository, InventoryRepository>();
    }
}
