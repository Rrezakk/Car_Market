using Market.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Models;

public class Manufacturer : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<EvCar> Cars { get; set; }
}
