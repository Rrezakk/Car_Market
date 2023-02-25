using Market.Domain.ViewModels.EvCar;
using Market.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
        try
        {
            ViewBag.AlertMessage = TempData["AlertMessage"];
            ViewBag.AlertType = TempData["AlertType"];
        }
        catch (Exception e)
        {
            //ignored
        }
        
        var response = await _evCarService.GetCars();
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            return View(response.Data.ToList());
        }
        return View("Error", $"{response.Description}");
    }
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var response = await _evCarService.GetCar(id);
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            return View(response.Data);
        }
        return View("Error", $"{response.Description}");
    }
    [HttpPost]//[HttpDelete] is it necessary?
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _evCarService.DeleteCar(id);
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            TempData["AlertMessage"] = "Entity deleted successfully.";
            TempData["AlertType"] = "success";
            return RedirectToAction("GetAll");
        }
        return View("Error", $"{response.Description}");
    }
    [HttpGet]
    public async Task<IActionResult> Save(int id)
    {
        if (id == 0) 
            return PartialView();

        var response = await _evCarService.GetCar(id);
        if (response.StatusCode == Domain.Enums.StatusCode.Ok)
        {
            return PartialView(response.Data);
        }
        ModelState.AddModelError("", response.Description);
        return PartialView();
    }

    [HttpPost]
    public async Task<IActionResult> Save(EvCarViewModel viewModel)
    {
        ModelState.Remove("Id");
        ModelState.Remove("ManufacturerName");
        ModelState.Remove("Name");
        ModelState.Remove("UploadedImage");
        if (ModelState.IsValid)
        {
            var imageData = Array.Empty<byte>();
            if (viewModel.Id == 0)
            {
                if (viewModel.UploadedImage == null)
                {
                    return RedirectToPage("Error");//so?
                }
                using var binaryReader = new BinaryReader(viewModel.UploadedImage.OpenReadStream());
                imageData = binaryReader.ReadBytes((int)viewModel.UploadedImage.Length);
                await _evCarService.CreateCar(viewModel, imageData);
                TempData["AlertMessage"] = "Entity created successfully.";
                TempData["AlertType"] = "success";
            }
            else
            {
                if (viewModel.UploadedImage != null)
                {
                    using var binaryReader = new BinaryReader(viewModel.UploadedImage.OpenReadStream());
                    imageData = binaryReader.ReadBytes((int)viewModel.UploadedImage.Length);
                }
                await _evCarService.Edit(viewModel, imageData);
                TempData["AlertMessage"] = "Entity Edited successfully.";
                TempData["AlertType"] = "success";
            }
        }
        return RedirectToAction("GetAll");
    }
    [HttpGet]
    public async Task<string> GetCarTypes()
    {
        var types =  _evCarService.GetTypes();
        return JsonConvert.SerializeObject(types.StatusCode==Domain.Enums.StatusCode.Ok? types.Data:new Dictionary<int, string>());
    }
    [HttpGet]
    public async Task<string> GetPlugTypes()
    {
        var types =  _evCarService.GetPlugTypes();
        return JsonConvert.SerializeObject(types.StatusCode==Domain.Enums.StatusCode.Ok? types.Data:new Dictionary<int, string>());
    }
}