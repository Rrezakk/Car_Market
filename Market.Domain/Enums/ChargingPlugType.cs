using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Enums;

public enum ChargingPlugType
{
    [Display(Name = "Первый тип")]
    Type1 =0,
    [Display(Name = "Второй тип")]
    Type2=1
}
