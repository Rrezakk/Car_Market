using Market.DataAccessLayer.Extensions;
using Market.Domain.Enums;
using Market.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Market.DataAccessLayer;

public sealed class ApplicationDbContext:DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
    {
        Database.EnsureCreated();
    }
    public DbSet<EvCar> Cars { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Basket> Baskets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyUtcDateTimeConverter();//Put before seed data and after model creation
        modelBuilder.Entity<Manufacturer>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(100);
        });
        
        modelBuilder.Entity<User>(b =>
        {
            b.HasData(new User()
            {
                Id = 1,
                Name = "admin",
                PasswordHash = Domain.Helpers.HashPasswordHelper.HashPassword("admin"),
                Role = Role.Admin
            });
            b.HasKey(x => x.Id);
            b.Property(x => x.Id).ValueGeneratedOnAdd();
            b.Property(x => x.PasswordHash).IsRequired();
            b.Property(x => x.Name).HasMaxLength(100).IsRequired();
            b.HasOne(x => x.Profile)
                .WithOne(x => x.User)
                .HasPrincipalKey<User>(x => x.Id)
                .OnDelete(DeleteBehavior.Cascade);
            b.HasOne(x => x.Basket)
                .WithOne(x => x.User)
                .HasPrincipalKey<User>(x => x.Id);
          
        });
        modelBuilder.Entity<EvCar>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasOne(x => x.Manufacturer).WithMany(x => x.Cars)
                .HasForeignKey(x => x.ManufacturerId);
        });
        modelBuilder.Entity<UserProfile>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Id).ValueGeneratedOnAdd();
                b.Property(x => x.Age);
                b.Property(x => x.Address).HasMaxLength(200).IsRequired(false);
                
                b.HasData(new UserProfile()
                {
                    Id = 1,
                    UserId = 1,
                    Address = "",
                    Age = 20,
                });
            });
        modelBuilder.Entity<Basket>(builder =>
        {
            builder.HasKey(x => x.Id);
                
            builder.HasData(new Basket() 
            {
                Id = 1,
                UserId = 1,
            });
        });
            
        modelBuilder.Entity<Order>(builder =>
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(r => r.Basket).WithMany(t => t.Orders)
                .HasForeignKey(r => r.BasketId);
        });
        
        
    }
}
