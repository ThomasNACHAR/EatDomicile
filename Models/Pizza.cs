namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;


public class Pizza : Food 
{
    public Dough Dough { get; set; } = null!;
}