using Microsoft.AspNetCore.Mvc;

namespace Market.Controllers;

public class AdminPanelController : Controller
{
    // GET
    public IActionResult General()
    {
        return View();
    }
}
