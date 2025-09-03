namespace EatDomicile.Data;

using Microsoft.EntityFrameworkCore;
using EatDomicile.Models;

public class EatDomicileContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=EatDomicile;User Id=sa;Password=Hogan2003!;TrustServerCertificate=True;");
    }
}