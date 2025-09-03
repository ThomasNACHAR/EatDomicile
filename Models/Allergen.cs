namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Allergen
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;
    
    public ICollection<Product> Products { get; set; } = new List<Product>();

}