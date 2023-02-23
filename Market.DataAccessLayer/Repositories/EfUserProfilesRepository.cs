using Market.DataAccessLayer.Abstractions;
using Market.Domain.Models;

namespace Market.DataAccessLayer.Repositories;

public class EfUserProfilesRepository:AbstractEfRepository<UserProfile,ApplicationDbContext>
{
    public EfUserProfilesRepository(ApplicationDbContext context) : base(context)
    {
    }
}
