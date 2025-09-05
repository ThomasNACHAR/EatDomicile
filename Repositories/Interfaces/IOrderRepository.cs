namespace EatDomicile.Repositories;

using EatDomicile.Models;

public interface IOrderRepository<T> : IRepository<T> where T : Order
{
    IEnumerable<Order> GetOrdersByStatus(string status);
    Order? GetOrderDetails(Guid orderId);
    IEnumerable<Order> GetOrdersByUser(Guid userId);
}