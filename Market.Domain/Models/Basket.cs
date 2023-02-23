using Market.Domain.Interfaces;

namespace Market.Domain.Models;

public class Basket:IEntity
{
    public int Id { get; set; }
        
    public virtual User User { get; set; }
        
    public long UserId { get; set; }
        
    public virtual List<Order> Orders { get; set; }
}
