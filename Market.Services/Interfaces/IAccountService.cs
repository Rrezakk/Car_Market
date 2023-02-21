using Market.Domain.Response;
using Market.Domain.ViewModels.Account;
using System.Security.Claims;

namespace Market.Services.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
    Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
}
