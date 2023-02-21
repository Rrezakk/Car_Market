using AutoMapper;
using Market.Domain.Models;

namespace Market.Domain.MappingProfiles;

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<ViewModels.Account.RegisterViewModel, User>().ForMember(x=>x.PasswordHash,c=>
            c.MapFrom(x=>Helpers.HashPasswordHelper.HashPassword(x.Password)));
    }
}
