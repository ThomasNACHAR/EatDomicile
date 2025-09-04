namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public abstract class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public double KCal { get; set; }
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    
    public ICollection<Allergen> Allergens { get; set; } = new List<Allergen>();
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

}