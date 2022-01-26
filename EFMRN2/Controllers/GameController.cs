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
  public void MovePlayer(int playerId, bool n, bool s, bool e, bool w)
  {
    Player player = FindPLayer(playerId);
    var Destination = GetDestination(player, n, s, e, w);
    Tile targetTile;
    if(CheckTransparency(Destination[0],Destination[1],Destination[2]))
    {
      targetTile = _db.Map.FirstOrDefault(t=>t.X==Destination[0]&&t.Y==Destination[1]&&t.Z==Destination[2]);
      MapController.list[1].TileAction(player, targetTile);
      player.X = Destination[0];
      player.Y = Destination[1];
      player.Z = Destination[2];
      _db.Entry(player).State = EntityState.Modified;
      _db.SaveChanges();
    }
    targetTile = null;
    MapController.list[1].TileAction(player, targetTile);
  }
    public bool CheckTransparency(int x, int y, int z)
    {
      var target = _db.Map.AsQueryable();
      target= target.Where(t=>t.X == x&&t.Y==y&&t.Z==z);
      Tile output = target.FirstOrDefault();
      return output.Transparent;
        
    }
    public Player FindPLayer(int playerId)
    {
      Player player = _db.Players.FirstOrDefault(p => p.PlayerId == playerId);
      return player;
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