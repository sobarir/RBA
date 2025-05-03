namespace RBA.Repository;

public interface IRepositoryBase<T> where T : class
{

  Task<T> CreateAsync(T entity);

  Task<T?> GetAsync(object? id);

  Task<IEnumerable<T>> GetAllAsync();

  Task<bool> UpdateAsync(T entity);

  Task<bool> DeleteAsync(object? id);

}
