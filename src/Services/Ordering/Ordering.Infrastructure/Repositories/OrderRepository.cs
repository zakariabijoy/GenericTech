﻿using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories;

public class OrderRepository : RepositoryBase<Order>, IOrderRepository
{
    readonly OrderContext _orderContext;

    public OrderRepository(OrderContext orderContext) :base(orderContext)
    {
        _orderContext = orderContext;   
    }

    public async Task<IEnumerable<Order>> GetOrdersByUserName(string userName) => await _orderContext.Orders.Where(x => x.UserName == userName).ToListAsync();  
}
