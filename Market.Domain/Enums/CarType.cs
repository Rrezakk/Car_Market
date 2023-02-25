using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Enums;

public enum CarType
{
    [Display(Name = "Легковой автомобиль")]
    Saloon =0,
    [Display(Name = "Хэтчбэк")]
    Hatchback=1,
    [Display(Name = "Внедорожник")]
    Suv=2,
    [Display(Name = "Купе")]
    COUPE =3,
    [Display(Name = "Универсал")]
    ESTATE=4,
    [Display(Name = "Кабриолет")]
    CABRIO=5
    
}
