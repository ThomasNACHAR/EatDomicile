namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Dough
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = null!;

}