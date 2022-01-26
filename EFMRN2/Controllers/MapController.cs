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
    private Tile _tempTile;
    public MapController(EFMRN2Context db)
    {
        _db = db;
        MapController.list.Add(this);
    }
    //Still have to call this when player moves
    public void TileAction(Player one, Tile targetTile)
    {
      Tile target = GetPlayerTile(one);
      switch(target.Method)
      {
        case 1:
        //the doing
        Door(one);
        break;
        case 2:
        MudTile(one, targetTile);
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
      t.Transparent = true;
      //replace with texture name of open door
      t.Texture = "walkable";
      t.Aux = "open";
      _db.Entry(t).State = EntityState.Modified;
      _db.SaveChanges();
    }
    public void CloseTile(Tile t)
    {
      t.Transparent = true;
      //replace with texture name of closed door
      t.Texture = "walkable";
      t.Aux = "closed";
      _db.Entry(t).State = EntityState.Modified;
      _db.SaveChanges();
    }
    //teleport to plain tile in front of door
    public void Door(Player p)
    {
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
      Tile targetA = GetPlayerTile(p);
      int i = Int32.Parse(targetA.Aux);
      Tile target = GetTileById(i);
      if(target.Aux == "closed")
      {
        OpenTile(target);
      }
      if(target.Aux == "open")
      {
        CloseTile(target);
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
        */

        /*
          If you are on mud and the target tile is mud change the target tiles aux to MOVE BACK 
          and then if the targetTile is MOVE BACK TO X Y Z, do that and change aux back to mud
        */
    public void MudTile(Player p, Tile targetTile)
    {
      Tile targetA = GetPlayerTile(p);
      _tempTile = targetA;
      if(targetTile.Aux == "mud")
      {
        targetTile.Aux = "move back";
        _db.Entry(targetTile).State = EntityState.Modified;
        _db.SaveChanges();
      } 
      if(targetA.Aux == "move back")
      {
        SetPlayerPos(p, _tempTile);
        targetA.Aux = "mud";
        _db.Entry(targetA).State = EntityState.Modified;
        _db.SaveChanges();
      }
    }
    public void TrapDoor(Player p)
    {
      Tile holeTile = GetPlayerTile(p);
      Door(p);
      holeTile.Texture = "hole";
      _db.Entry(holeTile).State = EntityState.Modified;
      _db.SaveChanges();
    }
  }
}
/*
  Tiles: 
  
  Door Tile
  AUX = Position to move to, in front of other door

  PressurePlate
  Aux = targetBlocked tile
  Aux of target blocked tile = closed
  also need to figure out exact texture names for open and closed

  Mud tile
  Aux = mud
*/