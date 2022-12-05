using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
    public IActionResult Index() => View(repository.Listings.AsEnumerable());
    
    [Authorize]
    public IActionResult Create() => View();

    [HttpPost][Authorize]
    public RedirectResult Create(Listing auctionlist)
    {
        if(ModelState.IsValid)
        {
            _db.Add(auctionlist);
            _db.SaveChanges();
        }
        return Redirect("/");
    }
    public IActionResult Listing(long id, string message = "")
    {
        var userName = User?.Identity?.Name;
        ViewData["Listing"] = repository.Listings.SingleOrDefault(d => d.ListingId == id);
        ViewData["Comments"] = _db.Comments.Where(c => c.ListingId == id).ToList();
        var contx = _db.WatchLists.Where(s => s.Username == userName).Select(n => n.ListingId).ToArray();
        var cont = _db.Bids.SingleOrDefault(i => i.ListingId == id);
        ViewBag.watchList = contx.Contains(id);
        ViewBag.winner = cont?.UserName;
        ViewBag.msg = message;
        return View();
    }

    public IActionResult Categories()
    {
        var contx = repository.Listings.Select(c => c.Category).Distinct().ToList();
        return View(contx);
    }

    public IActionResult CategoryList(string category)
    {
        ViewBag.category = category;
        return View(repository.Listings.Where(c => c.Category == category));
    }

    public IActionResult ClosedListings()
    {
        return View(repository.Listings.Where(c => c.ActiveStatus == false));
    }

    public IActionResult Comment() => View("comment");

    public IActionResult SaveComment(Comment newComment, long id)
    {
        if (ModelState.IsValid)
        {
            _db.Add(newComment);
            _db.SaveChanges();
        }
        return RedirectToAction("Listing", new{@id=id});
    }

    public IActionResult Bids() => View();

    [HttpPost]
    public IActionResult Bid(long id, decimal amount)
    {
        var userName = User?.Identity?.Name;
        var message = "";
        var item = _db.Bids.SingleOrDefault(d => d.ListingId == id);
        var listing = repository.Listings.SingleOrDefault(d => d.ListingId == id);
        Bid newBid = new Bid{
            Amount = amount, UserName = userName, ListingId = id
        };

        if (item != null)
        {
            if (item.Amount < amount)
            {
                _db.Bids.Remove(item);
                _db.Bids.Add(newBid);
                _db.SaveChanges();
                message = "Bid Accepted!";
            }
            else
            {
                message = "Bid Not Accepted!";
            }

        } else 
        {
            Console.WriteLine(listing?.StartAmount);
            if (listing?.StartAmount < amount)
            {
                _db.Bids.Add(newBid);
                _db.SaveChanges();
                message = "Bid Accepted!";
            }
            else
            {
                message = "Bid Not Accepted!";
            }
        }

        Console.WriteLine("UserId: "+ userName);
        Console.WriteLine("ListingID: "+ id);
        Console.WriteLine("Amount: "+ amount);

        return RedirectToAction("Listing", new{@id=id, @message=message});
    }

    public IActionResult CloseBid(long id)
    {
        var item = _db.Listings.FirstOrDefault(d => d.ListingId == id);
        if (item != null)
        {
            item.ActiveStatus = false;
            _db.SaveChanges();
        }

        return RedirectToAction("Listing", new{@id=id});
    }

    public IActionResult AddWatchItem(WatchList newWatchlist, long id)
    {
        var userName = User?.Identity?.Name;
        if (userName != null)
        {
            WatchList watchList = new WatchList {Username = userName, ListingId = id};
            _db.WatchLists.Add(watchList);
            _db.SaveChanges();
        }
        return RedirectToAction("Listing", new{@id=id});
    }

    public IActionResult RemoveItem(long id)
    {
        var userName = User?.Identity?.Name;
        var item = _db.WatchLists.Where(s => s.Username == userName).SingleOrDefault(n => n.ListingId == id);
        if (item != null)
        {
            _db.WatchLists.Remove(item);
            _db.SaveChanges();
        }

        return RedirectToAction("Listing", new{@id=id});
    }

    public IActionResult WatchLists()
    {
        var userName = User?.Identity?.Name;
        // ViewBag.watchlist = _db.WatchLists.Where(s => s.Username == userName).Select(n => n.ListingId);
        // ViewData["Listing"] = repository.Listings.Join(_db.WatchLists, d => d.ListingId, i => i.ListingId, (d,i) => new {
            
        // });

        ViewData["watchList"] = from l in repository.Listings
                    from w in _db.WatchLists
                    where l.ListingId == w.ListingId && w.Username == userName
                    select new {
                        l.ListingId,
                        l.ActiveStatus,
                        l.ImageUrl,
                        l.StartAmount,
                        l.Title
                    };
        return View();
    }
}