using System.Linq.Expressions;
using ContactApp.Contact.Application.Abstractions;
using ContactApp.Contact.Domain.Abstractions;
using ContactApp.Contact.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace ContactApp.Contact.Persistence.Repositories;

public class Repository<T, TId> : IRepository<T, TId> where T : class, IEntity<TId>, new()
{
    private readonly ContactAppDbContext _context;

    public Repository(ContactAppDbContext context)
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

    public async Task<T> GetAync(Expression<Func<T, bool>> predicate = null)
    {
        return await Table.Where(predicate).FirstOrDefaultAsync();
    }

    public async Task<IList<T>> GetListAync(Expression<Func<T, bool>> predicate = null)
    {
        return await Table.Where(predicate).ToListAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        Table.Update(entity);
        await _context.SaveChangesAsync();
    }
}

