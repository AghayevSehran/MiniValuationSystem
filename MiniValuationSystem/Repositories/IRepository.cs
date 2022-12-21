namespace MiniValuationSystem.Repositories;

public interface IRepository<T> where T : class
{
    IAsyncEnumerable<T> GetAll();
}
