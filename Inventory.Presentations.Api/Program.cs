using Inventory.Core.Business;
using Inventory.Core.Business.Gateways;
using Inventory.Database.Context;
using Inventory.Gateways;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<InventoryContext>(o => o.UseInMemoryDatabase(databaseName: "inventory-db"));
}
else
{
    // TODO: connect to persistent database
}

builder.Services.AddTransient<IGetInventoriesGateway, GetInventoriesGateway>();
builder.Services.AddTransient<ISaveInventoryGateway, SaveInventoryGateway>();
builder.Services.AddTransient<IUpdateInventoryGateway, UpdateInventoryGateway>();

builder.Services.AddTransient<CreateInventory>();
builder.Services.AddTransient<GetInventories>();
builder.Services.AddTransient<UpdateInventory>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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