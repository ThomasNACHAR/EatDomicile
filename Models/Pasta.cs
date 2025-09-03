namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Pasta : Food 
{
    public string Type { get; set; } = null!;
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

}