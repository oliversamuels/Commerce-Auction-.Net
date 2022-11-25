using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Commerce.Models;

namespace Commerce.Controllers;

public class UserController : Controller
{
    public UserManager<IdentityUser> UserManager;
    private SignInManager<IdentityUser> signInManager;

    public string? ReturnUrl {get; set; }

    public UserController(UserManager<IdentityUser> usrManager, SignInManager<IdentityUser> signinMgr)
    {
        UserManager = usrManager;
        signInManager = signinMgr;
    }

    public IActionResult Index() => View();
    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Login(Users loginUser)
    {
        if (ModelState.IsValid)
        {
            Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(ReturnUrl ?? "/");
            }
            ModelState.AddModelError("", "Invalid username or password");
        }
        return RedirectToPage("/");
    }

    [HttpPost]
    public async Task<IActionResult> Create(Users newUser)
    {
        if (ModelState.IsValid)
        {
            IdentityUser user = new IdentityUser { UserName = newUser.UserName, Email = newUser.Email };

            IdentityResult result = await UserManager.CreateAsync(user, newUser.Password);

            if (result.Succeeded)
            {
                return Redirect("/User");
            }
            foreach (IdentityError err in result.Errors)
            {
                ModelState.AddModelError("", err.Description);
            }
        }
        return View();
    }

    public async Task<IActionResult> Logout(){
        await signInManager.SignOutAsync();
        return Redirect("/");
    }
}