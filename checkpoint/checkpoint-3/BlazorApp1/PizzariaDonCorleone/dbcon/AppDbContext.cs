using Microsoft.EntityFrameworkCore;
using PizzariaDonCorleone.Models;

namespace PizzariaDonCorleone.dbcon;

public class AppDbContext : DbContext 
{
    public DbSet<Pizza> Pizzas { get; set; }
    
    public DbSet<Cart> carts { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    { 
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}