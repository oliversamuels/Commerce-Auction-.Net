using Microsoft.EntityFrameworkCore;
using Commerce.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = "server=localhost;user=root;password=Y@ungwarlok1;database=auction";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));

builder.Services.AddDbContext<DataContext>(opts => 
{
    opts.UseMySql(connectionString, serverVersion);
    opts.EnableSensitiveDataLogging(true);
    opts.EnableDetailedErrors();
});


var app = builder.Build();
//app.MapGet("/", () => "Hello World!");

var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();
SeedData.SeedDatabase(context);

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();