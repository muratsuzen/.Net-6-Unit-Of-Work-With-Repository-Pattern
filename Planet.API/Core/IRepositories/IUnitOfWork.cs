namespace Planet.API.Core.IRepositories;

public interface IUnitOfWork
{
    IGenericRepository<T> GenericRepository<T>() where T : class;
    Task CompleteAsync();

}