using MyShop.Web.API.Broker.DateTimes;
using MyShop.Web.API.Broker.Loggings;
using MyShop.Web.API.Broker.Storages;
using MyShop.Web.API.Services.Foundation.Products;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StorageBroker>();

ServiceBrokers(builder);

builder.Services.AddTransient<IProductService, ProductService>();

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

static void ServiceBrokers(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IStorageBroker, StorageBroker>();
    builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
    builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
}