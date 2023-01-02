using System.Linq.Expressions;
using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Domain.Abstractions;
using ContactApp.Contact.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Contact.Persistence.Repositories;

public class Repository<T> : IRepository<T> where T : class, IEntity, new()
{
    private readonly ApplicationDbContext _context;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
    }

    private DbSet<T> Table { get => _context.Set<T>(); }

    public async Task<T> AddAsync(T entity)
    {
        var addedEntityEntry = await Table.AddAsync(entity);
        addedEntityEntry.State = EntityState.Added;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        Table.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includes)
    {
        var query = Table.AsQueryable();

        query = query.Where(predicate);

        if (includes != null)
        {
            query = includes.Aggregate(query, (current, include) => current.Include(include));
        }

        return await query.FirstOrDefaultAsync();
    }

    public async Task<IList<T>> GetListAync(Expression<Func<T, bool>> predicate = null)
    {
        var query = Table.AsQueryable();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
    }
}

