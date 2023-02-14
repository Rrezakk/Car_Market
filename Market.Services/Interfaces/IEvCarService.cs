using Market.Domain.Models;
using Market.Domain.Response;
using Market.Domain.ViewModels.EvCar;

namespace Market.Services.Interfaces;

public interface IEvCarService
{
    Task<IBaseResponse<IEnumerable<EvCar>>> GetCars();
    Task<IBaseResponse<EvCar>> GetCar(int id);
    Task<IBaseResponse<bool>> CreateCar(EvCarCreateViewModel evCarCreateViewModel);
    Task<IBaseResponse<bool>> DeleteCar(int id);
    Task<IBaseResponse<EvCar>> Edit(EvCarCreateViewModel model);
}
