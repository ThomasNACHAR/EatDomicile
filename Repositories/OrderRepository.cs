namespace EatDomicile.Repositories;

using EatDomicile.Models;
using EatDomicile.Data;

public class OrderRepository<T> : Repository<T>, IOrderRepository<T> where T : Order
{
    public OrderRepository(EatDomicileContext context) : base(context)
    {
        
    }

    public IEnumerable<Order> GetOrdersByStatus(string status)
    {
        return _context.Orders
            .Where(o => o.Status == status)
            .ToList();
    }

    /* void UpdateOrderStatus(Guid orderId, string status)
    {
        var order = GetById(orderId);
        if (order == null)
            throw new Exception("Commande introuvable.");
        order.Status = status;
        Update(order);
        Save();
    } */
   Order? GetOrderDetails(Guid orderId)
    {
        return _context.Orders
            .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
            .Include(o => o.Address)
            .Include(o => o.User)
            .FirstOrDefault(orderId);
    }
    void AddItemsToOrder(IEnumerable<OrderItem> orderItems);

    IEnumerable<Order> GetOrdersByUser(Guid userId)
    {
        return _context.Orders
            .Include(o => o.User)
            .Where(o => o.User.Id == userId)
            .ToList();
    }
}