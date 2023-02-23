using Market.DataAccessLayer.Abstractions;
using Market.Domain.Models;

namespace Market.DataAccessLayer.Repositories;

public class EfOrderRepository:AbstractEfRepository<Order,ApplicationDbContext>
{
    public EfOrderRepository(ApplicationDbContext context) : base(context)
    {
    }
}
