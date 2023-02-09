using Market.Domain.Enums;
namespace Market.Domain.Models;

public class Car
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Model { get; set; }
    public int TopSpeed { get; set; }
    public decimal Price { get; set; }
    public DateTime CreationTime { get; set; }
    public CarType Type { get; set; }
}

