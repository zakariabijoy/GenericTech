﻿using GenericTech.ASPNETCoreWebApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace GenericTech.ASPNETCoreWebApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Contact> Contacts { get; set; }
}
