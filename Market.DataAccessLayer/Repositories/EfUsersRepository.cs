using Market.Domain.Models;

namespace Market.DataAccessLayer.Abstractions;

public class EfUsersRepository:AbstractEfRepository<User,ApplicationDbContext>
{
    public EfUsersRepository(ApplicationDbContext context) : base(context)
    {

    }
    
}
