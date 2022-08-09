using Planet.API.Core.IRepositories;
using Planet.API.Data;

namespace Planet.API.Core.Repositories;

public class UnitOfWork:IUnitOfWork,IDisposable
{
    private DefaultContext _context;

    public UnitOfWork(DefaultContext context)
    {
        _context = context;
    }
    
    public IGenericRepository<T> GenericRepository<T>() where T : class
    {
        return new GenericRepository<T>(_context);
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}