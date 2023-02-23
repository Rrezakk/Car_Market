using System.ComponentModel.DataAnnotations;

namespace Market.Domain.ViewModels.Profile;

public class ProfileViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Укажите возраст")]
    [Range(18,140,ErrorMessage = "Укажите реальный возраст, старше 18 лет")]
    public int Age { get; set; }
    [Required(ErrorMessage = "Укажите адрес")]
    [MaxLength(5,ErrorMessage = "Минимальная длина должна быть 5 символов")]
    [MinLength(250,ErrorMessage = "Максимальная длина 250 символов")]
    public string Address { get; set; }
}
