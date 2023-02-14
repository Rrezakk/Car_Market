using Market.Domain.Models;

namespace Market.DataAccessLayer.Interfaces;

public interface IBaseRepository<T>
{
     Task<bool> Create(T entity);
     
     Task<EvCar> Get(int id);
     
     Task<List<EvCar>> Select();
     
     Task<bool> Delete(T entity);
}
