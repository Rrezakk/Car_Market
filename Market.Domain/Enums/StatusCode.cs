namespace Market.Domain.Enums;

public enum StatusCode
{
    Ok=200,
    NotFound=404,
    InternalServerError = 500,
    CarsNotFound = 1001,
    CarNotFound =1002,
    CreateCarViewModelNull =1003,
    UserNotFound = 2001,
    InvalidPassword = 2002,
    ManufacturersDataNull = 2500,
}
