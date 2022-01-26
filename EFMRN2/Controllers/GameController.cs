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
    public MapController dave;
    public GameController(EFMRN2Context db)
    {
      _db = db;
      dave = new MapController(db);
    }


  [HttpGet]
  public ActionResult<Tile> Get(int x, int y, int z)
  {
    Tile target = _db.Map.AsQueryable()
      .Where(t=>t.X == x && t.Y == y && t.Z == z)
      .FirstOrDefault();
    return target;
  }
  [HttpGet("fMap")]
  public ActionResult<IEnumerable<Tile>> GetMap(int pid, int range)
  {
    Player tp = _db.Players.FirstOrDefault(p=>p.PlayerId == pid);
    List<Tile> target = _db.Map.AsQueryable()
      .Where(t=>(t.X>=(tp.X-range)&&t.X<=(tp.X+range))&&(t.Y>=(tp.Y-range)&&t.Y<=(tp.Y+range))).OrderBy(t=>t.Y).ThenBy(t=>t.X).ToList();
    return target;
  }
  [HttpGet("fPlayer")]
  public ActionResult<IEnumerable<Player>> GetLocalPlayer(int pid, int range)
  {
    Player tp = _db.Players.FirstOrDefault(p=>p.PlayerId == pid);
    List<Player> target = _db.Players.AsQueryable()
      .Where(t=>t.PlayerId!=pid&&(t.X>=(tp.X-range)&&t.X<=(tp.X+range))&&(t.Y>=(tp.Y-range)&&t.Y<=(tp.Y+range))).OrderBy(t=>t.Y).ThenBy(t=>t.X).ToList();
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
  [HttpGet("user")]
  public ActionResult<Player> GetPlayerById(string pid)
  {
    Player target = _db.Players.FirstOrDefault(p=>p.UserId==pid);
    return target;
  }


  [HttpGet("move")]
  public async Task<ActionResult<Player>> MovePlayer(int pid, bool n, bool s, bool e, bool w)
  {
    int[] Destination = GetDestination(pid, n, s, e, w);

    
    if(CheckTransparency(Destination[0],Destination[1],Destination[2]))
    {
      Player target = await _db.Players.FindAsync(pid);

      Tile targetTile = _db.Map.FirstOrDefault(t=>t.X==Destination[0]&&t.Y==Destination[1]&&t.Z==Destination[2]);

      dave.TileAction(target, targetTile);
      target.X = Destination[0];
      target.Y = Destination[1];
      target.Z = Destination[2];
      _db.Entry(target).State = EntityState.Modified;
      await _db.SaveChangesAsync();
      dave.TileAction(target, targetTile);
    }
    return RedirectToAction("GetPlayer", new {id = pid});
  }

  
    public bool CheckTransparency(int x, int y, int z)
    {
      // var target = _db.Map.AsQueryable();
      // target= target.Where(t=>t.X == x&&t.Y==y&&t.Z==z);
      // Tile output = target.FirstOrDefault();
      // return output.Transparent;
        return _db.Map.FirstOrDefault(t=>t.X==x&&t.Y==y&&t.Z==z).Transparent;
    }



    public Player FindPLayer(int playerId)
    {
      Player player = _db.Players.FirstOrDefault(p => p.PlayerId == playerId);
      return player;
    }
    public int[] GetDestination(int id, bool n, bool s, bool e, bool w)
    {
      // n = 0| s = 1| e = 2| w = 3
      Player target = _db.Players.FirstOrDefault(p=>p.PlayerId==id);
      int[] output = {target.X,target.Y,target.Z};
       if(n)
      {
        output[1]-=1;
      }
      if(s)
      {
        output[1]+=1;
      }
      if(e)
      {
        output[0]+=1;
      }
      if(w)
      {
        output[0]-=1;
      }
      
      if(output[1]<target.Y)
      {
        target.Bearing=1;
      }
      if(output[1]>target.Y)
      {
        target.Bearing=0;
      }
      if(output[0]<target.X)
      {
        target.Bearing=3;
      }
      if(output[0]>target.X)
      {
        target.Bearing=2;
      }
      _db.Entry(target).State = EntityState.Modified;
    return output;
    }
  }
}