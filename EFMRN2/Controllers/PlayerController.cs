using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;

using EFMRN2.Models;

namespace EFMRN2.Controllers
{
  public class PlayerController : Controller
  {
    private readonly EFMRN2Context _db;
    private readonly UserManager<ApplicationUser> _userManager;

    public PlayerController(UserManager<ApplicationUser> userManager, EFMRN2Context db)
    {
      _userManager = userManager;
      _db = db;
    }

    [HttpPost]
    public IActionResult Edit(Player player)
    {
      _db.Entry(player).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
    public ActionResult MovePlayer(Player player, bool n, bool s, bool e, bool w)
    {
      var Destination = GetDestination(player, n, s, e, w);
      if(CheckTransparency(Destination[0],Destination[1],Destination[2]))
      {
        player.X = Destination[0];
        player.Y = Destination[1];
        player.Z = Destination[2];
        _db.Entry(player).State = EntityState.Modified;
        _db.SaveChanges();
      }
      return RedirectToAction("TileAction","Map", new {p=player});
    }
    public bool CheckTransparency(int x, int y, int z)
    {
      var target = _db.Map.AsQueryable();
      target= target.Where(t=>t.X == x&&t.Y==y&&t.Z==z);
      Tile output = target.FirstOrDefault();
      return output.Transparent;
        
    }
    public int[] GetDestination(Player player, bool n, bool s, bool e, bool w)
    {
      // n = 0| s = 1| e = 2| w = 3
      int destx = player.X;
      int desty = player.Y;
      if(n)
      {
        desty+=1;
      }
      if(s)
      {
        desty-=1;
      }
      if(e)
      {
        destx+=1;
      }
      if(w)
      {
        destx-=1;
      }
      
      if(desty<player.Y)
      {
        player.Bearing=1;
      }
      if(desty>player.Y)
      {
        player.Bearing=0;
      }
      if(destx<player.X)
      {
        player.Bearing=3;
      }
      if(destx>player.X)
      {
        player.Bearing=2;
      }
      _db.Entry(player).State = EntityState.Modified;
    return(new int[] {destx, desty, player.Z});
    }
  }
}
