using AutoMapper;
using Market.Domain.Enums;
using Market.Domain.Models;
using Market.Domain.ViewModels.EvCar;

namespace Market.Domain.MappingProfiles;

public class EvCarMappingProfile:Profile
{
    public EvCarMappingProfile()
    {
        // CreateMap<EvCarViewModel, EvCar>().ForMember(x => x.Type,
        //         opt =>
        //             opt.MapFrom(src => (CarType)Convert.ToInt32(src.Type)))
        //     .ForMember(x => x.PlugType,
        //         opt =>
        //             opt.MapFrom(src => Enum.Parse<ChargingPlugType>(src.PlugType)));
        // .ForMember(x => x.,
        //     opt =>
        //         opt.MapFrom(src => Enum.Parse<ChargingPlugType>(src.PlugType)));
        CreateMap<EvCarViewModel, EvCar>()
            .ForMember(x => x.Image, opt => opt.Ignore());

        CreateMap<EvCar, EvCarViewModel>().ForMember(x => x.Name, z =>
                z.MapFrom(y => (y.Manufacturer.Name + " " + y.Model)))
            .ForMember(x => x.ManufacturerId, y =>
                y.MapFrom(z => z.Manufacturer.Id))
            .ForMember(x => x.ManufacturerName, y =>
                y.MapFrom(z => z.Manufacturer.Name))
            .ForMember(x=>x.Image,y=>
                y.MapFrom(z=>z.Image));
    }
}
