using Market.Domain.Response;

namespace Market.Services.Interfaces;

public interface IManufacturerService
{
    public Task<BaseResponse<Dictionary<int, string>>> GetManufacturersSelectData();
}
