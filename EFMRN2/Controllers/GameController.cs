using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EFMRN2.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Cors;
using System;

namespace EFMRN2.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GameController: ControllerBase
  {
    private readonly EFMRN2Context _db;
    public GameController(EFMRN2Context db)
    {
      _db = db;
    }
  [HttpGet]
  public ActionResult<Tile> Get(int x, int y, int z)
  {
    Tile target = _db.Map.AsQueryable().Where(t=>t.X == x && t.Y == y && t.Z == z).FirstOrDefault();
    return target;
  }
  [HttpGet("AllPlayers")]
  public async Task<ActionResult<IEnumerable<Player>>> GetAllPlayer()
  {
    
    return await _db.Players.ToListAsync();
  }
  [HttpGet("player")]
  public async Task<ActionResult<Player>> GetPlayer(int id)
  {
    Player target = await _db.Players.FindAsync(id);
    return target;
  }
  }
}