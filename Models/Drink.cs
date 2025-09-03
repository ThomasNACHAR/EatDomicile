namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Drink : Product
{
    public bool Fizzy { get; set; } = false;

}