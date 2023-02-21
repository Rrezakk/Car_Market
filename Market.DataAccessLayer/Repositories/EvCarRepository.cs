using Market.DataAccessLayer.Interfaces;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccessLayer.Repositories;

public class EvCarRepository:IEvCarRepository
{
    private readonly ApplicationDbContext _db;

    public EvCarRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<bool> Create(EvCar evCar)
    {
        await _db.Cars.AddAsync(evCar);
        await _db.SaveChangesAsync();
        return true;
    }
    public async Task<EvCar?> Get(int id)
    {
        return await _db.Cars.FirstOrDefaultAsync(x => x.Id == id);//wait, what if null?
    }
    public IQueryable<EvCar> GetAll()
    {
        return _db.Cars;
    }
    public async Task<bool> Delete(EvCar entity)
    {
        _db.Cars.Remove(entity);
        await _db.SaveChangesAsync();
        return true;
    }
    public async Task<EvCar> Update(EvCar entity)
    {
        _db.Cars.Update(entity);
        await _db.SaveChangesAsync();
        return entity;
    }

}
