namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime OrderDate { get; set; } = DateTime.Now;
    public DateTime DeliveryDate { get; set; }
    public string Status { get; set; } = "en attente";
    
    public User User { get; set; } = null!;
    public Address Address { get; set; } = null!;
    
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


}