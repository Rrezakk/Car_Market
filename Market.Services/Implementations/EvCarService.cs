using AutoMapper;
using Market.DataAccessLayer.Repositories;
using Market.Domain.Enums;
using Market.Domain.Extensions;
using Market.Domain.Models;
using Market.Domain.Response;
using Market.Domain.ViewModels.EvCar;
using Market.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Services.Implementations;

public class EvCarService:IEvCarService
{
    private readonly EfEvCarRepository _evCarRepository;
    private readonly IMapper _mapper;
    public EvCarService(EfEvCarRepository evCarRepository, IMapper mapper)
    {
        _evCarRepository = evCarRepository;
        _mapper = mapper;
    }
    public BaseResponse<Dictionary<int, string>> GetTypes()
    {
        try
        {
            var types = ((CarType[]) Enum.GetValues(typeof(CarType)))
                .ToDictionary(k => (int) k, t => t.GetDisplayName());
            return new BaseResponse<Dictionary<int, string>>()
            {
                Data = types,
                StatusCode = StatusCode.Ok
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Dictionary<int, string>>()
            {
                Description = $"[GetTypes]: {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    public BaseResponse<Dictionary<int, string>> GetPlugTypes()
    {
        try
        {
            var types = ((ChargingPlugType[]) Enum.GetValues(typeof(ChargingPlugType)))
                .ToDictionary(k => (int) k, t => t.GetDisplayName());
            return new BaseResponse<Dictionary<int, string>>()
            {
                Data = types,
                StatusCode = StatusCode.Ok
            };
        }
        catch (Exception e)
        {
            return new BaseResponse<Dictionary<int, string>>()
            {
                Description = $"[GetPlugTypes]: {e.Message}",
                StatusCode = StatusCode.InternalServerError
            };
        }
    }
    public async Task<IBaseResponse<bool>> CreateCar(EvCarViewModel? evCarCreateViewModel,byte[] imageData)
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
            model.Image = imageData;
            await _evCarRepository.Add(model);
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
    public async Task<IBaseResponse<bool>> DeleteCar(int id)//maybe do not check existence? -> less queries
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
            await _evCarRepository.Delete(car.Id);
            baseResponse.Data = true;
            baseResponse.StatusCode = StatusCode.Ok;
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
    public async Task<IBaseResponse<EvCar>> Edit(EvCarViewModel model,byte[]? newImage)
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
            _mapper.Map<EvCarViewModel,EvCar>(model, car);
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
    public async Task<IBaseResponse<EvCarViewModel>> GetCar(int id)
    {
        var baseResponse = new BaseResponse<EvCarViewModel>();
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
            baseResponse.Data = _mapper.Map<EvCarViewModel>(car);
            return baseResponse;
        }
        catch (Exception e)
        {
            return new BaseResponse<EvCarViewModel>()
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
            var cars = await _evCarRepository.GetAll().ToListAsync();
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
