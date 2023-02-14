using Market.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers;

public class EvCarController:Controller
{
    private readonly IEvCarService _evCarService;
    public EvCarController(IEvCarService evCarService)
    {
        _evCarService = evCarService;
    }
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var response = await _evCarService.GetCars();
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            return View(response.Data);
        }
        return NotFound();
    }
}
