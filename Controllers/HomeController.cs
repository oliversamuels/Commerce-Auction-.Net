using Microsoft.AspNetCore.Mvc;
using Commerce.Models;

namespace Commerce.Controllers;

public class HomeController : Controller
{
    private IListingRepository repository;
    private DataContext _db;

    public HomeController(IListingRepository repo, DataContext db)
    {
        repository = repo;
        _db = db;
    }
    public IActionResult Index() => View(repository.Listings);
    
    public IActionResult Create() => View();

    [HttpPost]
    public RedirectResult Create(Listing auctionlist)
    {
        if(ModelState.IsValid)
        {
            _db.Add(auctionlist);
            _db.SaveChanges();
        }
        return Redirect("/");
    }
    public IActionResult Listing(long id)
    {
        var contx = repository.Listings.Single(d => d.ListingId == id);
        return View(contx);
    }

    public IActionResult Categories()
    {
        var contx = repository.Listings.Select(c => c.Category).Distinct().ToList();
        return View(contx);
    }
}