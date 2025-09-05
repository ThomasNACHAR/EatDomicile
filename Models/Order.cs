namespace EatDomicile.Models;

using System.ComponentModel.DataAnnotations;

public class Order
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime OrderDate { get; set; } = DateTime.Now;
    public DateTime DeliveryDate { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    
    public User User { get; set; } = null!;
    public Address Address { get; set; } = null!;
    
    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();


}