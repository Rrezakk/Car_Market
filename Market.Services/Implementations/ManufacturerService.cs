using Market.DataAccessLayer.Repositories;
using Market.Domain.Enums;
using Market.Domain.Response;
using Market.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Market.Services.Implementations;

public class ManufacturerService:IManufacturerService
{
    private readonly EfManufacturersRepository _manufacturersRepository;
    public ManufacturerService(EfManufacturersRepository manufacturersRepository)
    {
        _manufacturersRepository = manufacturersRepository;
    }
    public async Task<BaseResponse<Dictionary<int, string>>> GetManufacturersSelectData()
    {
        var response = new BaseResponse<Dictionary<int, string>>();
        try
        {
            var data = await _manufacturersRepository.GetAll().ToDictionaryAsync(x=>x.Id,y=>y.Name);
            if (data.Count == 0)
            {
                return new BaseResponse<Dictionary<int, string>>()
                {
                    StatusCode = StatusCode.ManufacturersDataNull,
                    Description = "Manufacturers data was null or empty"
                };
            }
            response.Data = data;
            response.StatusCode = StatusCode.Ok;
            return response;
        }
        catch (Exception e)
        {
            return new BaseResponse<Dictionary<int, string>>()
            {
                StatusCode = StatusCode.InternalServerError,
                Description = $"[GetManufacturersSelectData]: {e.Message}"
            };
        }
        
        
    }
}
