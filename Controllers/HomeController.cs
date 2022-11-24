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

    [HttpGet("{id}")]
    public IActionResult Listing(long id)
    {
        var contx = repository.Listings.Where(d => d.ListingId.Equals(id));
        return View(contx);
    }
}