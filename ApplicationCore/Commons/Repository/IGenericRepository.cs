using ApplicationCore.Interfaces.Criteria;

namespace ApplicationCore.Interfaces.Repository;

public interface IGenericRepository<T, K> where T: IIdentity<K> where K : IComparable<K>
{
    Task<T?> FindByIdAsync(K id);
    Task<List<T>> FindAllAsync();

    T? FindById(K id);

    List<T> FindAll();
    T Add(T o);
    
    void RemoveById(K id);
    
    void Update(K id, T o);
    
    IEnumerable<T> FindBySpecification(ISpecification<T> specification = null);
}