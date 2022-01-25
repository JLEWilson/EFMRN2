using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using EFMRN2.Models;
using EFMRN2.ViewModels;

namespace EFMRN2.Controllers
{
  public class AccountController : Controller
  {
    private readonly EFMRN2Context _db;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, EFMRN2Context db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View();
    }
    public IActionResult Register()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Register (RegisterViewModel model)
    {
      var user = new ApplicationUser { UserName = model.Email };
      IdentityResult result = await _userManager.CreateAsync(user, model.Password);
      if (result.Succeeded)
      {
        // var newPlayer = new Player{UserId = user.Id, X = 0, Y = 0, Z = 0, Transparency = false, Bearing = 2, Color = "red"};
        // newPlayer.UserId = user.Id;
        // newPlayer.X = 0;
        // newPlayer.Y = 0;
        // newPlayer.Z = 0;
        // newPlayer.Transparency = false;
        // newPlayer.Bearing = 2;
        // newPlayer.Color = "red";
        _db.Players.Add(new Player{UserId = user.Id, X = 0, Y = 0, Z = 0, Transparency = false, Bearing = 2, Color = "red"});
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
      else
      {
        return View();
      }
    }
    public ActionResult Login()
    {
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel model)
    {
      Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
      if (result.Succeeded)
      {
          return RedirectToAction("Index");
      }
      else
      {
          return View();
      }
    }
    public async Task<ActionResult> LogOff()
    {   
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index");
    }
  }
}