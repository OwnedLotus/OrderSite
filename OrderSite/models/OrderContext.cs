using Microsoft.EntityFrameworkCore;
using OrderSite.Models;
using System.Collections.Generic;

public class OrderContext : DbContext
{
    public DbSet<Order> Orders { get; set; } = default!;

    public string DbPath { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<Order>().HasIndex(o => o.OrderNumber);
    }

    public OrderContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "order.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }
}