using Microsoft.EntityFrameworkCore;

namespace Commerce.Models;

public static class SeedData
{
    public static void SeedDatabase(DataContext context)
    {
        context.Database.Migrate();
        if (context.Listings.Count() == 0)
        {
            context.Listings.AddRange(
                new Listing { Title = "Kayak", StartAmount = 1.200m}
            );

            context.SaveChanges();
        }
    }
}