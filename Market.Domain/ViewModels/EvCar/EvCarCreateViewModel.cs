namespace Market.Domain.ViewModels.EvCar;

public class EvCarCreateViewModel//later - validation attributes
{
    public int Id { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string Type { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public int Range { get; set; }
    public float Power { get; set; }
    public float BatterySize { get; set; }
    public bool FastChargeAvailable { get; set; }
    public int Seats { get; set; }
    public float AccelerationTime { get; set; }
    public string PlugType { get; set; }
    public DateTime TimeAdded { get; set; }
}
