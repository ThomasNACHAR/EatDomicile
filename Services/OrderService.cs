namespace EatDomicile.Services;

using EatDomicile.Models;
using EatDomicile.Repositories;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

public class OrderSerivce
{
    private readonly IOrderRepository<Order> _orderRepository;

    public OrderService(IOrderRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public void CreateOrder(Order order)
    {
        _orderRepository.Add(order);
        _orderRepository.Save();
    }
    
    
}