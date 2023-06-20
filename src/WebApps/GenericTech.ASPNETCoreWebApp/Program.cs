using GenericTech.ASPNETCoreWebApp.Data;
using GenericTech.ASPNETCoreWebApp.Extensions;
using GenericTech.ASPNETCoreWebApp.Repositories;
using GenericTech.ASPNETCoreWebApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

#region database services

//// use in-memory database
//services.AddDbContext<ApplicationDbContext>(c =>
//    c.UseInMemoryDatabase("DefaultConnection"));

// add database dependecy
builder.Services.AddDbContext<ApplicationDbContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

#region project services

// add repository dependecy
builder.Services.AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<ICartRepository, CartRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IContactRepository, ContactRepository>();

#endregion

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

app.SeedDatabase();

app.Run();
