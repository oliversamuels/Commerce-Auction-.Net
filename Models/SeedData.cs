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
                new Listing { Title = "Honda Accord", StartAmount = 26520, Category = "Midsize", Description = "The 2022 Honda Accord may be aging but it’s still top dog among family sedans, with lots of style, class-leading room and an enviable set of features", ImageUrl = "https://www.forbes.com/wheels/cars/honda/accord/"},
                
                new Listing { Title = "Hyundai Sonata", StartAmount = 24150, Category = "Midsize", Description = "The Hyundai Sonata is a compelling midsize sedan with value, class-leading tech and a potent performance model. But it isn’t without a few shortcomings.", ImageUrl = "https://www.forbes.com/wheels/cars/hyundai/sonata/2022/"},

                new Listing { Title = "Kia K5", StartAmount = 23790, Category = "Midsize", Description = "The 2022 Kia K5 represents the best of Kia’s sedan legacy, with distinctive styling, a beautiful cabin, lots of features and up to 290 horsepower.", ImageUrl = "https://www.forbes.com/wheels/cars/kia/k5/"},

                new Listing { Title = "Mercedes-Benz S-Class", StartAmount = 114500, Category = "Luxury", Description = "Though it now shares a double-bill with the electric EQS, the more traditional 2023 Mercedes-Benz S-Class is still at the top of the luxury limo pack..", ImageUrl = "https://www.forbes.com/wheels/cars/mercedes-benz/s-class/"},

                new Listing { Title = "Genesis G80", StartAmount = 48250, Category = "Luxury", Description = "The 2022 Genesis G80 is a sublimely luxurious midsize sedan that’s packed with features and beautiful details. It's arguably better than its German rivals.", ImageUrl = "https://www.forbes.com/wheels/cars/genesis/g80/"},

                new Listing { Title = "Audi A8", StartAmount = 86500, Category = "Luxury", Description = "The 2022 Audi A8 and S8 get a refresh, but you’d hardly know by looking at it given its evolutionary styling. It’s a lovely limo, but so are its competitors.", ImageUrl = "https://www.forbes.com/wheels/cars/audi/a8/"},

                new Listing { Title = "Mercedes-Benz C-Class", StartAmount = 41600, Category = "Small Luxury", Description = "The Mercedes-Benz C-Class offers lots of luxury, solid performance, attractive styling, and a wealth of competitive features.", ImageUrl = "https://www.forbes.com/wheels/cars/mercedes-benz/c-class/2021/"},

                new Listing { Title = "BMW i4", StartAmount = 55400, Category = "Small Luxury", Description = "The 2022 BMW i4 is the first all-electric sports sedan from BMW that starts under $60,000 with 300-mile range.", ImageUrl = "https://www.forbes.com/wheels/cars/bmw/i4/"},

                new Listing { Title = "BMW 4 Series", StartAmount = 45600, Category = "Small Luxury", Description = "The 2021 BMW 4 Series is a powerful, sharp-dressed, and surprisingly efficient luxury coupe with one particularly controversial feature, its oversize grille.", ImageUrl = "https://www.forbes.com/wheels/cars/bmw/4-series/2021/"}
            );

            context.SaveChanges();
        }
    }
}