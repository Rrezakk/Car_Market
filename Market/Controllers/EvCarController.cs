using Market.Domain.ViewModels.EvCar;
using Market.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers;

public class EvCarController : Controller
{
    private readonly IEvCarService _evCarService;
    public EvCarController(IEvCarService evCarService)
    {
        _evCarService = evCarService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await _evCarService.GetCars();
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            return View(response.Data);
        }
        return NotFound();
    }
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _evCarService.GetCar(id);
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            return View(response.Data);
        }
        return NotFound();
    }
    [HttpPost]//[HttpDelete] is it necessary?
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _evCarService.DeleteCar(id);
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            return RedirectToAction("GetAll");
        }
        return NotFound();
    }
    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Save(int id)
    {
        if (id == 0)
        {
            return View();
        }
        var response = await _evCarService.GetCar(id);
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            return View(response.Data);
        }
        return NotFound();
    }
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Save(EvCarCreateViewModel evCarCreateViewModel)
    {
        if (ModelState.IsValid)
        {
            if (evCarCreateViewModel.Id == 0)
            {
                await _evCarService.CreateCar(evCarCreateViewModel);
            }
            else
            {
                await _evCarService.Edit(evCarCreateViewModel);
            }
        }
        return NotFound();
    }
}