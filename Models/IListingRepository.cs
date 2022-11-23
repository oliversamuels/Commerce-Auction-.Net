namespace Commerce.Models;

public interface IListingRepository
{
    IQueryable<Listing> Listings {get; }
}