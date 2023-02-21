using AutoMapper;
using Market.DataAccessLayer.Interfaces;
using Market.Domain.Enums;
using Market.Domain.Models;
using Market.Domain.Response;
using Market.Domain.ViewModels.EvCar;
using Market.Services.Interfaces;

namespace Market.Services.Implementations;

public class EvCarService:IEvCarService
{
    private readonly IEvCarRepository _evCarRepository;
    private readonly IMapper _mapper;
    public EvCarService(IEvCarRepository evCarRepository, IMapper mapper)
    {
        _evCarRepository = evCarRepository;
        _mapper = mapper;
    }
    public async Task<IBaseResponse<bool>> CreateCar(EvCarCreateViewModel evCarCreateViewModel)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            if (evCarCreateViewModel == null)
            {
                baseResponse.Description = $"Create car model was null";
                baseResponse.StatusCode = StatusCode.CreateCarViewModelNull;
                return baseResponse;
            }
            var model = _mapper.Map<EvCar>(evCarCreateViewModel);
            await _evCarRepository.Create(model);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.Ok;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Data = false,
                Description = $"[Create car']: {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    public async Task<IBaseResponse<bool>> DeleteCar(int id)
    {
        var baseResponse = new BaseResponse<bool>();
        try
        {
            var car = await _evCarRepository.Get(id);
            if (car == null)
            {
                baseResponse.Data = false;
                baseResponse.StatusCode = StatusCode.CarNotFound;
                baseResponse.Description = $"car with id {id} not found";
                return baseResponse;
            }
            await _evCarRepository.Delete(car);
            baseResponse.Data = true;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<bool>()
            {
                Data = false,
                Description = $"[Delete car']: {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    public async Task<IBaseResponse<EvCar>> Edit(EvCarCreateViewModel model)
    {
        var baseResponse = new BaseResponse<EvCar>();
        try
        {
            var car = await _evCarRepository.Get(model.Id);
            if (car == null)
            {
                baseResponse.StatusCode = StatusCode.CarNotFound;
                baseResponse.Description = $"car with id {model.Id} not found";
                return baseResponse;
            }
            _mapper.Map<EvCarCreateViewModel,EvCar>(model, car);
            await _evCarRepository.Update(car);

            baseResponse.StatusCode = StatusCode.Ok;
            baseResponse.Data = car;
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<EvCar>()
            {
                Description = $"[Edit car']: {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
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
                Description = $"[Get car']: {e.Message}",
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
