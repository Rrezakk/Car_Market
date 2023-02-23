using Market.DataAccessLayer.Abstractions;
using Market.Domain.Models;

namespace Market.DataAccessLayer.Repositories;

public class EfBasketRepository:AbstractEfRepository<Basket,ApplicationDbContext>
{
    public EfBasketRepository(ApplicationDbContext context) : base(context)
    {
    }
}
