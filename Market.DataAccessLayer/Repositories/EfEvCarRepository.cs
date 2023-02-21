using Market.DataAccessLayer.Abstractions;
using Market.DataAccessLayer.Interfaces;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccessLayer.Repositories;

public class EfEvCarRepository:AbstractEfRepository<EvCar,ApplicationDbContext>
{
    public EfEvCarRepository(ApplicationDbContext db) : base(db)
    {
    }
}
