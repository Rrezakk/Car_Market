using AutoMapper;
using Market.DataAccessLayer;
using Market.DataAccessLayer.Abstractions;
using Market.Domain.Enums;
using Market.Domain.Helpers;
using Market.Domain.Models;
using Market.Domain.Response;
using Market.Domain.ViewModels.Account;
using Market.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Market.Services.Implementations;

public class AccountService:IAccountService
{
    private readonly EfUsersRepository _userRepository;
    private readonly IMapper _mapper;
    public AccountService(EfUsersRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
            if (user != null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь с таким логином уже есть",
                };
            }
            user = _mapper.Map<User>(model);
            await _userRepository.Add(user);
            var result = Authenticate(user);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                Description = "Объект добавляется",
                StatusCode = StatusCode.Ok,
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = $"[Register]: {e.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
    public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
    {
        try
        {
            var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Name == model.Name);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Пользователь не найден",
                    StatusCode = StatusCode.UserNotFound,
                };
            }
            if (user.PasswordHash != HashPasswordHelper.HashPassword(model.Password))
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Введен неверный пароль",
                    StatusCode = StatusCode.InvalidPassword,
                };
            }
            var result = Authenticate(user);
            return new BaseResponse<ClaimsIdentity>()
            {
                Data = result,
                StatusCode = StatusCode.Ok,
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<ClaimsIdentity>()
            {
                Description = $"[Login]: {e.Message}",
                StatusCode = StatusCode.InternalServerError,
            };
        }
    }
    private ClaimsIdentity Authenticate(User user)
    {
        var claims = new List<Claim>()
        {
            new Claim(ClaimsIdentity.DefaultNameClaimType,user.Name),
            new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role.ToString())
        };
        return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
    }
}
