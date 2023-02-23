using Market.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Market.Domain.Models;

public class Order:IEntity
{
    public int Id { get; set; }
        
    public long? CarId { get; set; }

    public DateTime DateCreated { get; set; }

    public string Address { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int? BasketId { get; set; }
    public virtual Basket Basket { get; set; }
}
