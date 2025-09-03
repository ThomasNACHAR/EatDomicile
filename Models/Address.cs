namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Address
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Zip { get; set; } = null!;
    public string Country { get; set; } = null!;


}