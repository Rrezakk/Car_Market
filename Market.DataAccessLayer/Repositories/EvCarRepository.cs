using Market.DataAccessLayer.Interfaces;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccessLayer.Repositories;

public class EvCarRepository:ICarRepository
{
    private readonly ApplicationDbContext _db;

    public EvCarRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public bool Create(EvCar evCar)
    {
        throw new NotImplementedException();
    }
    public EvCar Get(int id)
    {
        throw new NotImplementedException();
    }
    public async Task<List<EvCar>> Select()
    {
        return await _db.Cars.ToListAsync();
    }
    public bool Delete(EvCar entity)
    {
        throw new NotImplementedException();
    }
    
}
