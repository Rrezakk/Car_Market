using Market.DataAccessLayer.Interfaces;
using Market.Domain.Enums;
using Market.Domain.Models;
using Market.Domain.Response;
using Market.Services.Interfaces;

namespace Market.Services.Implementations;

public class EvCarService:IEvCarService
{
    private readonly IEvCarRepository _evCarRepository;
    public EvCarService(IEvCarRepository evCarRepository)
    {
        _evCarRepository = evCarRepository;
    }

    public async Task<IBaseResponse<EvCar>> GetCar(int id)
    {
        var baseResponse = new BaseResponse<EvCar>();
        try
        {
            var car = await _evCarRepository.Get(id);
            if (car == null)
            {
                baseResponse.StatusCode = StatusCode.CarNotFound;
                baseResponse.Description = $"car with id {id} not found";
                return baseResponse;
            }
            baseResponse.StatusCode = StatusCode.Ok;
            baseResponse.Data = car;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<EvCar>()
            {
                Description = $"[Get cars']: {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    public async Task<IBaseResponse<IEnumerable<EvCar>>> GetCars()
    {
        var baseResponse = new BaseResponse<IEnumerable<EvCar>>();
        try
        {
            var cars = await _evCarRepository.Select();
            if (cars.Count == 0)
            {
                baseResponse.Description = "Получен пустой список";
                baseResponse.StatusCode = StatusCode.CarsNotFound;
                return baseResponse;
            }
            baseResponse.StatusCode = StatusCode.Ok;
            baseResponse.Data = cars;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<IEnumerable<EvCar>>() { Description = $"[GetCars] : {e.Message}",StatusCode = StatusCode.InternalServerError};
        }
    }
}
