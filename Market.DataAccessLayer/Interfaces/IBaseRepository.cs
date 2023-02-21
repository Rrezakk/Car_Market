using Market.Domain.Interfaces;

namespace Market.DataAccessLayer.Interfaces;

public interface IBaseRepository<T> where T : class, IEntity
{
     IQueryable<T> GetAll();
     Task<T?> Get(int id);
     Task<T> Add(T entity);
     Task<T> Update(T entity);
     Task<T?> Delete(int id);
}
