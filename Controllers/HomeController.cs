using Microsoft.AspNetCore.Mvc;
using Commerce.Models;

namespace Commerce.Controllers;

public class HomeController : Controller
{
    private IListingRepository repository;

    public HomeController(IListingRepository repo)
    {
        repository = repo;
    }
    public IActionResult Index() => View(repository.Listings);
}