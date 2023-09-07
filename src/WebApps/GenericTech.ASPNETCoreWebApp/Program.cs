using Common.Logging;
using GenericTech.ASPNETCoreWebApp.Services;
using GenericTech.ASPNETCoreWebApp.Services.Interfaces;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

//serilog configuration
builder.Host.UseSerilog(SeriLogger.Configure);

// Add services to the container.

//Configure Typed Clients with IHttpClientFactory
builder.Services.AddTransient<LoggingDelegatingHandler>();

builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
    c.BaseAddress = new Uri(configuration["APISettings:GatewayAddress"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>();

builder.Services.AddHttpClient<IBasketService, BasketService>(c =>
    c.BaseAddress = new Uri(configuration["APISettings:GatewayAddress"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>();

builder.Services.AddHttpClient<IOrderService, OrderService>(c =>
    c.BaseAddress = new Uri(configuration["APISettings:GatewayAddress"]))
    .AddHttpMessageHandler<LoggingDelegatingHandler>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
