using Market.Domain.Enums;

namespace Market.Domain.Response;

public interface IBaseResponse<T>
{
    string Description { get; set; }
    StatusCode StatusCode { get; set; }
    T Data { get; set; }
}
