using Market.Domain.Enums;
using Market.Domain.Interfaces;

namespace Market.Domain.Models;

public class User:IEntity
{
    public int Id { get; set; }
    public string PasswordHash { get; set; }
    public string Name { get; set; }
    public Role Role { get; set; }
    public virtual UserProfile Profile { get; set; }
    public virtual Basket Basket { get; set; }
}
