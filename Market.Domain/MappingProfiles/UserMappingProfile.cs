using AutoMapper;
using Market.Domain.Models;

namespace Market.Domain.MappingProfiles;

public class UserMappingProfile:Profile
{
    public UserMappingProfile()
    {
        CreateMap<ViewModels.Account.RegisterViewModel, User>().ForMember(x=>x.PasswordHash,c=>
            c.MapFrom(x=>Helpers.HashPasswordHelper.HashPassword(x.Password)));
    }
}
