namespace EatDomicile.Data;

using Microsoft.EntityFrameworkCore;
using EatDomicile.Models;

public class EatDomicileContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Dough> Doughs { get; set; } = null!;
    public DbSet<Ingredient> Ingredients { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Pizza> Pizzas { get; set; } = null!;
    public DbSet<Pasta> Pastas { get; set; } = null!;
    public DbSet<Burger> Burgers { get; set; } = null!;
    public DbSet<Drink> Drinks { get; set; } = null!;
    public DbSet<Allergen> Allergens { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EatDomicile;User Id=sa;Password=Hogan2003!;TrustServerCertificate=True;");
    }
}