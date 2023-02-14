using Market.Domain.Models;
using Market.Domain.Response;

namespace Market.Services.Interfaces;

public interface IEvCarService
{
    Task<IBaseResponse<IEnumerable<EvCar>>> GetCars();
}
