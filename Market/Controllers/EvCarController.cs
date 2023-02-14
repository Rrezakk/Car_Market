using Market.DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers;

public class EvCarController:Controller
{
    private readonly IEvCarRepository _evEvCarRepository;
    public EvCarController(IEvCarRepository evEvCarRepository)
    {
        _evEvCarRepository = evEvCarRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var response = await _evEvCarRepository.Select();
        return View(response);
    }
}
