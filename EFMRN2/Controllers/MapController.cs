using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFMRN2.Models;
using Microsoft.EntityFrameworkCore;

namespace EFMRN2.Controllers
{
  public class MapController : Controller
  {
    private readonly EFMRN2Context _db;
    public static List<MapController> list = new List<MapController>();
    // private Tile _tempTile;
    // private Tile pressurePlateDownTile;
    public MapController(EFMRN2Context db)
    {
        _db = db;
        MapController.list.Add(this);
    }
    //Still have to call this when player moves
    public void TileAction(Player one)
    {
      
      Tile target = GetPlayerTile(one);
      switch(target.Method)
      {
        case 1:
        //the doing
        Door(one);
        break;
        case 2:
        //MudTile(one);
        break;
        case 3:
        PressurePlateToggle(one);
        break;
        case 4:
        PressurePlateKey(one);
        break;
        default:
        break;
      }
    }

    
    public Tile GetPlayerTile(Player p)
    {
      Tile target = _db.Map.FirstOrDefault(t=>t.X==p.X&&t.Y==p.Y&&t.Z==p.Z);
      return target;
    }
    public Tile GetTileById(int id)
    {
      Tile target = _db.Map.FirstOrDefault(t=>t.TileId == id);
      return target;
    }
    public void SetPlayerPos(Player p, Tile t)
    {
      Player target =_db.Players.FirstOrDefault(pl=>pl.PlayerId == p.PlayerId);
      target.X = t.X;
      target.Y = t.Y;
      target.Z = t.Z;
      _db.Entry(target).State = EntityState.Modified;
      _db.SaveChanges();
    }
    public void OpenTile(Tile t)
    {
      Console.WriteLine("OpenTile");
      t.Transparent = true;
      t.Texture = "floor";
      t.Aux = "open";
      _db.Entry(t).State = EntityState.Modified;
      _db.SaveChanges();
    }
    public void CloseTile(Tile t)
    {
      Console.WriteLine("CloseTile");
      t.Transparent = false;
      t.Texture = "wall";
      t.Aux = "0";
      _db.Entry(t).State = EntityState.Modified;
      _db.SaveChanges();
    }
    //teleport to plain tile in front of door
    public void Door(Player p)
    {
      Console.WriteLine("Door");
      Tile targetA = GetPlayerTile(p);
      int i = Int32.Parse(targetA.Aux);
      Tile target = GetTileById(i);
      SetPlayerPos(p,target);
    }
    //While occupied aux tile is transparent and has x texture,
    //after moving off aux tile reverts
    //
    public void PressurePlateKey(Player p)
    {
      Console.WriteLine("PressurePlateKey");
      Tile targetA = GetPlayerTile(p);
      int i = Int32.Parse(targetA.Aux);
      Tile target = GetTileById(i);
      Console.WriteLine(target.Aux);
      if(target.Aux == "0")
      {
        OpenTile(target);
      }
    }
    // V Currently functions like key, Change to toggle
    /*
    might need to adjust player move to calling tile action twice
    */
    public void PressurePlateToggle(Player p)
    {
      Console.WriteLine("PressurePlateToggle");
      Tile targetA = GetPlayerTile(p);
      int i = Int32.Parse(targetA.Aux);
      Tile target = GetTileById(i);
      Console.WriteLine(target.Aux);
      if(target.Aux == "0")
      {
        OpenTile(target);
      }
      else if(target.Aux == "open")
      {
        CloseTile(target);
      }
    }

    public void TrapDoor(Player p)
    {
      Tile holeTile = GetPlayerTile(p);
      Door(p);
      holeTile.Texture = "void";
      _db.Entry(holeTile).State = EntityState.Modified;
      _db.SaveChanges();
    }
    /*
        What am I even supposed to be doing right now I dont remember
        GameController changed from moving player every call regardless to only moving if the player is moving, breaking the adjustments we had to make in this file
        I no longer need to save player location when stepping on the pressure plate. I should be able to run it like I did before, which was change the auillery of a door to open when it is pressed, and to closed when you leave the tile
    */
        
    // public void MudTile(Player p)
    // {
    //   Tile targetA = GetPlayerTile(p);
    //   _tempTile = targetA;
    //   // if(targetTile.Aux == "mud")
    //   // {
    //   //   SetPlayerPos(p, _tempTile);
    //   //   _db.Entry(targetA).State = EntityState.Modified;
    //   //   _db.SaveChanges();
    //   // }
    // }
  }
}
/*
         tile A = tile standing on
         tile B = tile to move to
          
          get input directions
          check tile B
          if tile B walkable
          set var to tile B
          do action on tile A
          and the move to tile B

          then after move do action on tile you are now on
        
public void Mudslide(Player p)
{
  Tile targetA = GetPlayerTile(p);
  if (p.Bearing = N)
  {
    targetA.Aux = ConveyorS
  }
  else if (p.Bearing = E)
  {
    targetA.Aux = ConveyorW
  }
  else if (p.Bearing = W)
  {
    targetA.Aux = ConveyorE
  }
  else if (p.Bearing = S)
  {
    targetA.Aux = ConveyorN
  }
}

*/



    
    // public Tile GetForwardTile(Player p)
    // {
    //   //0=n, 2=s, 2=e, 3=w
    //   Player tempPlayer = p;
    //    if(p.Bearing == 0)
    //   {
    //     tempPlayer.Y -= 1;
    //   }
    //   if(p.Bearing == 1)
    //   {
    //     tempPlayer.Y += 1;
    //   }
    //   if()
    //   {
    //     output[0]+=1;
    //   }
    //   if()
    //   {
    //     output[0]-=1;
    //   }
      
      
    //   return output;
    // }
/*
  Tiles: 
  
  Mud
  Conveyer
  Ice
  ANYDAMAGING TILE will just be setplayerpos, but to start location
*/