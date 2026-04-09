using MongoDB.Driver;

public interface IMongoRepository<T>
{
    Task InsertAsync(T entity);

    Task<List<T>> GetAllAsync();

    Task<T?> GetByIdAsync(string id);

    Task<List<T>> FilterAsync(FilterDefinition<T> filter);

    Task<List<T>> GetPagedAsync(int page, int pageSize);

    Task DeleteAsync(string id);
}