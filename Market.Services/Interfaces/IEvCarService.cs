using Market.Domain.Models;
using Market.Domain.Response;
using Market.Domain.ViewModels.EvCar;

namespace Market.Services.Interfaces;

public interface IEvCarService
{
    BaseResponse<Dictionary<int, string>> GetTypes();
    BaseResponse<Dictionary<int, string>> GetPlugTypes();
    Task<IBaseResponse<IEnumerable<EvCar>>> GetCars();
    Task<IBaseResponse<EvCarViewModel>> GetCar(int id);
    Task<IBaseResponse<bool>> CreateCar(EvCarViewModel evCarCreateViewModel, byte[] imageData);
    Task<IBaseResponse<bool>> DeleteCar(int id);
    Task<IBaseResponse<EvCar>> Edit(EvCarViewModel model, byte[]? newImage);
}
