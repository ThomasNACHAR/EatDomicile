namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public abstract class Product
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public double KCal { get; set; }
    public double Price { get; set; }
    
    public ICollection<Allergen> Allergens { get; set; } = new List<Allergen>();

}