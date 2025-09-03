namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public abstract class Food : Product
{
    public bool Vegetarian { get; set; } = false;

}