namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public double KCal { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public ICollection<Burger> Burger { get; set; } = new List<Burger>();
    public ICollection<Pasta> Pastas { get; set; } = new List<Pasta>();

}