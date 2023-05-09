﻿using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Common;
using Ordering.Infrastructure.Persistence;
using System.Linq.Expressions;

namespace Ordering.Infrastructure.Repositories;

public class RepositoryBase<T> : IAsyncRepository<T> where T : EntityBase
{
    protected readonly OrderContext _orderContext;

    public RepositoryBase(OrderContext orderContext)
    {
        _orderContext = orderContext;
    }

    public async Task<T> AddAsync(T entity)
    {
        _orderContext.Set<T>().Add(entity);
        await _orderContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        _orderContext.Set<T>().Remove(entity);
        await _orderContext.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() => await _orderContext.Set<T>().ToListAsync();

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate) => await _orderContext.Set<T>().Where(predicate).ToListAsync();

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeString = null, bool disableTracking = true)
    {
        IQueryable<T> query = _orderContext.Set<T>();
        if(disableTracking) query = query.AsNoTracking();

        if(!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

        if(predicate != null) query = query.Where(predicate);  
        
        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();   
    }

    public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
    {
        IQueryable<T> query = _orderContext.Set<T>();
        if (disableTracking) query = query.AsNoTracking();

        if (includes != null) query = includes.Aggregate(query, (current, include) => current.Include(include));

        if (predicate != null) query = query.Where(predicate);

        if (orderBy != null)
            return await orderBy(query).ToListAsync();
        return await query.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) => await _orderContext.Set<T>().FindAsync(id);

    public async Task UpdateAsync(T entity)
    {
        _orderContext.Entry(entity).State = EntityState.Modified;
        await _orderContext.SaveChangesAsync();
    }
}
 