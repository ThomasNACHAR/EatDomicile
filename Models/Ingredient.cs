namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public double KCal { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Food> Foods { get; set; } = new List<Food>();

}