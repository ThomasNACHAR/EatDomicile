namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Pizza : Food 
{
    public Dough Dough { get; set; } = null!;
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}