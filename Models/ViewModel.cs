namespace Commerce.Models;

public class ViewModel
{
    public IEnumerable<Listing>? Listings {get; set;}
    public IEnumerable<Comment>? Comments {get; set;}
}