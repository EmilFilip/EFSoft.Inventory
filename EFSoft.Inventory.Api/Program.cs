var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsDevelopment())
{
    var appConfigurationConnectionString = builder.Configuration.GetValue<string>("AppConfigurationConnectionString");

    builder.Configuration.AddAzureAppConfiguration(config =>
    {
        config.Connect(appConfigurationConnectionString);
    });
}

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Product Microservice", Version = "v1" });
});

builder.Services.RegisterLocalServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
