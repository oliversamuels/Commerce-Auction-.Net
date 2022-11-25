using Microsoft.EntityFrameworkCore;
using Commerce.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = "server=localhost;user=root;password=Y@ungwarlok1;database=auction";
var identityConnection = "server=localhost;user=root;password=Y@ungwarlok1;database=identity";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddDbContext<DataContext>(opts => 
{
    opts.UseMySql(connectionString, serverVersion);
    opts.EnableSensitiveDataLogging(true);
    opts.EnableDetailedErrors();
});

builder.Services.AddDbContext<IdentityContext>(opts => opts.UseMySql(identityConnection, serverVersion));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddScoped<IListingRepository, EFListingRepository>();


var app = builder.Build();
//app.MapGet("/", () => "Hello World!");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.MapDefaultControllerRoute();

app.Run();