using Market.Services.Implementations;
using Market.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers;

public class ManufacturerController : Controller
{
    private readonly IManufacturerService _manufacturerService;
    // GET
    public ManufacturerController(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }
    [HttpGet]
    public async Task<JsonResult> ManufacturersSelectData()
    {
        var d = await _manufacturerService.GetManufacturersSelectData();
        return d.StatusCode == Domain.Enums.StatusCode.Ok? Json(d.Data):Json(new Dictionary<int, string>());
    }
}
