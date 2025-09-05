namespace EatDomicile.Services;

using EatDomicile.Models;
using EatDomicile.Repositories;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class OrderService
{
    private readonly IOrderRepository<Order> _orderRepository;
    private readonly IRepository<OrderItem> _orderItemRepository;

    public OrderService(IOrderRepository<Order> orderRepository, IRepository<OrderItem> orderItemRepository)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
    }

    public void CreateOrder(Order order)
    {
        _orderRepository.Add(order);
        _orderRepository.Save();
    }

    public Order? GetOrderById(Guid orderId)
    {
        return _orderRepository.GetById(orderId);
    }

    public IEnumerable<Order> GetOrdersByStatus(OrderStatus status)
    {
        return _orderRepository.GetOrdersByStatus(status);
    }
    
    public IEnumerable<Order> GetOrdersByUser(Guid userId)
    {
        return _orderRepository.GetOrdersByUser(userId);
    }
    
    public void UpdateOrderStatus(Guid orderId, OrderStatus status)
    {
        var order = GetOrderById(orderId);
        if (order == null)
            throw new Exception("Commande introuvable.");
        order.Status = status;
        _orderRepository.Update(order);
        _orderRepository.Save();
    }

    public void AddItemsToOrder(Guid orderId, IEnumerable<OrderItem> orderItems)
    {
        var order = GetOrderById(orderId);
        if (order == null)
            throw new Exception("Commande introuvable.");
        foreach (var orderItem in orderItems)
        {
            var existingItem = _orderRepository.FindExistingItem(order, orderItem);
            if (existingItem != null)
                existingItem.Quantity += orderItem.Quantity;
            else
                order.OrderItems.Add(orderItem);
        }
        _orderRepository.Update(order);
        _orderRepository.Save();
    }
    
    public Order? GetOrderDetails(Guid orderId)
    {
        return _orderRepository.GetOrderDetails(orderId);
    }

    public void AddOrderItem(OrderItem orderItem)
    {
        ValidateOrderItem(orderItem);
        _orderItemRepository.Add(orderItem);
        _orderItemRepository.Save();
    }

    public void RemoveItemFromOrder(Guid orderId, Guid orderItemId)
    {
        var order = GetOrderById(orderId);
        if (order == null)
            throw new Exception("Commande introuvable.");
        var orderItem = order.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
        if (orderItem == null)
            throw new Exception("Élément de commande introuvable.");
        order.OrderItems.Remove(orderItem);
        _orderItemRepository.Delete(orderItem);
        _orderRepository.Save();
        _orderItemRepository.Save();
    }

    public void UpdateOrderItemQuantity(Guid orderId, Guid orderItemId, int quantity)
    {
        if (quantity <= 0)
            throw new ArgumentException("La quantité doit être positive et non nulle.");
        var order = GetOrderById(orderId);
        if (order == null)
            throw new Exception("Commande introuvable.");
        var orderItem = order.OrderItems.FirstOrDefault(oi => oi.Id == orderItemId);
        if (orderItem == null)
            throw new Exception("Élément de commande introuvable.");
        orderItem.Quantity = quantity;
        _orderItemRepository.Update(orderItem);
        _orderItemRepository.Save();
    }

    public void ValidateOrderItem(OrderItem orderItem)
    {
        if (orderItem.Quantity <= 0)
            throw new ArgumentException("La quantité doit être positive et non nulle.");
    }
}