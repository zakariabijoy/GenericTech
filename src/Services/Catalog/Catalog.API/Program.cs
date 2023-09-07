using Catalog.API.Data;
using Catalog.API.Repositories;
using Common.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

//serilog configuration
builder.Host.UseSerilog(SeriLogger.Configure);

// Add services to the container.
builder.Services
    .AddScoped<ICatalogContext, CatalogContext>()
    .AddScoped<IProductRepository, ProductRepository>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
