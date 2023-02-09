using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Enums;

public enum CarType
{
    [Display(Name = "Легковой автомобиль")]
    PassengerCar =0,
    [Display(Name = "Спортивный автомобиль")]
    SportsCar=1,
    [Display(Name = "Внедорожник")]
    Suv =2,
    
}
