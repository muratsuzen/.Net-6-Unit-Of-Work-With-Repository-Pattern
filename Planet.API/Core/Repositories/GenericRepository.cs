using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Planet.API.Core.IRepositories;
using Planet.API.Data;

namespace Planet.API.Core.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private DefaultContext _context;

    public GenericRepository(DefaultContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<bool> Add(T entity)
    {
        EntityEntry<T> added = await _context.Set<T>().AddAsync(entity);
    }

    public async Task<bool> Update(T entity)
    {
        EntityEntry entityEntry = _context.Entry<T>(entity);
        entityEntry.State = EntityState.Modified;
        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);
        EntityEntry entityEntry = _context.Entry<T>(entity);
        entityEntry.State = EntityState.Deleted;
        return true;
    }
}