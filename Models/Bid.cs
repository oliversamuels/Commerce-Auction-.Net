namespace Commerce.Models;

public class Bid
{
    public long BidId {get; set; }
    public decimal Amount {get; set; }
    public IEnumerable<Listing>? Listings {get; set; }
}