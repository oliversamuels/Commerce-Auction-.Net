using Microsoft.AspNetCore.Mvc;

namespace Commerce.Controllers;

public class HomeController : Controller
{
    public IActionResult Index() => View();
}