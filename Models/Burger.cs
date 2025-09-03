namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Burger : Food 
{
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}