using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccessLayer;

public class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        
    }
    public DbSet<EvCar> Cars { get; set; }
    public DbSet<User> Users { get; set; }
}
