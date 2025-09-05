namespace EatDomicile.Repositories;

using EatDomicile.Models;
using EatDomicile.Data;
using Microsoft.EntityFrameworkCore;

public class OrderRepository<T> : Repository<T>, IOrderRepository<T> where T : Order
{
    public OrderRepository(EatDomicileContext context) : base(context)
    {
        
    }

    public IEnumerable<Order> GetOrdersByStatus(OrderStatus status)
    {
        return _context.Orders
            .Where(o => o.Status == status)
            .ToList();
    }
   public Order? GetOrderDetails(Guid orderId)
    {
        return _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .Include(o => o.Address)
            .Include(o => o.User)
            .FirstOrDefault(o => o.Id == orderId);
    }

    public IEnumerable<Order> GetOrdersByUser(Guid userId)
    {
        return _context.Orders
            .Include(o => o.User)
            .Where(o => o.User.Id == userId)
            .ToList();
    }

    public OrderItem? FindExistingItem(Order order, OrderItem orderItem)
    {
        return order.OrderItems.FirstOrDefault(oi => oi.Product.Id == orderItem.Product.Id);
    }
}