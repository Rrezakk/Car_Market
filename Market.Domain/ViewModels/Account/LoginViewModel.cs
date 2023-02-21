using System.ComponentModel.DataAnnotations;

namespace Market.Domain.ViewModels.Account;

public class LoginViewModel
{
    [Required(ErrorMessage = "Укажите имя")]
    [MaxLength(20,ErrorMessage = "Имя должно иметь длину не более 20 символов")]
    [MinLength(3,ErrorMessage = "Имя должно иметь длину не менее 3 символов")]
    public string Name { get; set; }
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [MinLength(8,ErrorMessage = "Пароль должен иметь длину не менее 8 символов")]
    public string Password { get; set; }
}
