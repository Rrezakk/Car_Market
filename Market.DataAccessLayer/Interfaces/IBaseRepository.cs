using Market.Domain.Models;

namespace Market.DataAccessLayer.Interfaces;

public interface IBaseRepository<T>
{
     bool Create(T entity);
     
     T Get(int id);
     
     Task<List<EvCar>> Select();
     
     bool Delete(T entity);
}
