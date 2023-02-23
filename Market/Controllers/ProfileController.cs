using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers;

public class ProfileController : Controller
{
    // GET
    public IActionResult Info()
    {
        return View();
    }
}
