namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class OrderItem
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public int Quantity { get; set; }
    
    public Order  Order { get; set; } = null!;
    
    public Product Product { get; set; } = null!;


}