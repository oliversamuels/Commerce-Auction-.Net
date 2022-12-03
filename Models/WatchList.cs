using System.ComponentModel.DataAnnotations;

namespace Commerce.Models;

public class WatchList
{
    public WatchList()
    {
        this.Listing = new HashSet<Listing>();
    }
    public long WatchListId {get; set; }
    public string Username {get; set; } = string.Empty;
    public long ListingId {get; set; }
    public virtual ICollection<Listing>? Listing { get; set; }
}