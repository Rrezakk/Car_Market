using Market.DataAccessLayer.Abstractions;
using Market.Domain.Models;

namespace Market.DataAccessLayer.Repositories;

public class EfManufacturersRepository:AbstractEfRepository<Manufacturer,ApplicationDbContext>
{
    public EfManufacturersRepository(ApplicationDbContext context) : base(context)
    {
    }
}
