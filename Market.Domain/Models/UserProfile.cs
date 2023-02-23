using Market.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Domain.Models;

public class UserProfile:IEntity
{
    public int Id { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
    public long UserId { get; set; }
    public virtual User User { get; set; }
}
