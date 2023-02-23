using AutoMapper;
using Market.Domain.Enums;
using Market.Domain.Models;
using Market.Domain.ViewModels.EvCar;

namespace Market.Domain.MappingProfiles;

public class EvCarMappingProfile:Profile
{
    public EvCarMappingProfile()
    {
        CreateMap<EvCarCreateViewModel, EvCar>().ForMember(x => x.Type,
                opt =>
                    opt.MapFrom(src => (CarType)Convert.ToInt32(src.Type)))
            .ForMember(x => x.PlugType,
                opt =>
                    opt.MapFrom(src => Enum.Parse<ChargingPlugType>(src.PlugType)));
        // .ForMember(x => x.,
        //     opt =>
        //         opt.MapFrom(src => Enum.Parse<ChargingPlugType>(src.PlugType)));
    }
}
