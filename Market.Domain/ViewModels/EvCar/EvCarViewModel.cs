using Market.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Market.Domain.ViewModels.EvCar;

public class EvCarViewModel
{
    public int Id { get; set; }
    public IFormFile? UploadedImage { get; set; }//only for Car creation
    public byte[]? Image { get; set; }//image of the car -> can be moved to cloud storage/ other db table for multiple ones
    public string Name { get; set; }//manufacturer + model
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; }
    public string Model { get; set; }
    public CarType Type { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public int Range { get; set; }
    public float Power { get; set; }
    public float BatterySize { get; set; }
    public bool FastChargeAvailable { get; set; }
    public int Seats { get; set; }
    public float AccelerationTime { get; set; }
    public ChargingPlugType PlugType { get; set; }
    public DateTime TimeAdded { get; set; }
}
