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
    private HomeController gary;

    private Tile _previousTile;
    public MapController(EFMRN2Context db)
    {
        _db = db;
        gary = new HomeController();
    }
    public void TileAction(Player one, bool leaving)
    {
      Tile target = GetPlayerTile(one);
      if(leaving)
      {
        _previousTile = target;
      }
      switch(target.Method)
      {
        case 1:
        Door(one);
        break;
        case 2:
        MudTile(one, leaving);
        break;
        case 3:
        PressurePlateToggle(one, leaving);
        break;
        case 4:
        PressurePlateKey(one);
        break;
        case 5:
        Ice(one, leaving);
        break;
        case 6:
        TrapDoor(one);
        break;
        case 7:
        SetSpawnPoint(one);
        gary.Death();
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
    //teleport to plain tile in front of door
    public void Door(Player p)
    {
      Console.WriteLine("Door");
      Tile targetA = GetPlayerTile(p);
      int i = Int32.Parse(targetA.Aux);
      Tile target = GetTileById(i);
      SetPlayerPos(p,target);
    }
    public void PressurePlateKey(Player p)
    {
      Console.WriteLine("PressurePlateKey");
      Tile targetA = GetPlayerTile(p);
      int i = Int32.Parse(targetA.Aux);
      Tile target = GetTileById(i);
      OpenTile(target);
    }
    public void PressurePlateToggle(Player p, bool leaving)
    {
      Console.WriteLine("PressurePlateToggle");
      Tile targetA = GetPlayerTile(p);
      int i = Int32.Parse(targetA.Aux);
      Tile target = GetTileById(i);
      if(leaving)
      {
        CloseTile(target);
      }
      else
      {
        OpenTile(target);
      }
    }
    public void OpenTile(Tile t)
    {
      Console.WriteLine("OpenTile");
      t.Transparent = true;
      t.Texture = "floor";
      _db.Entry(t).State = EntityState.Modified;
      _db.SaveChanges();
    }
    public void CloseTile(Tile t)
    {
      Console.WriteLine("CloseTile");
      t.Transparent = false;
      t.Texture = "wall";
      _db.Entry(t).State = EntityState.Modified;
      _db.SaveChanges();
    }
    public void TrapDoor(Player p)
    {
      Tile holeTile = GetPlayerTile(p);
      Door(p);
      holeTile.Texture = "void";
      _db.Entry(holeTile).State = EntityState.Modified;
      _db.SaveChanges();
    }
    public void MudTile(Player p, bool leaving)
    {
      Tile targetA = GetPlayerTile(p);
      if(!leaving && _previousTile.Texture == "mud")
      {
        SetPlayerPos(p, _previousTile);
      }
    }
    public void Ice(Player p, bool leaving)
    {
      Tile fTile = GetForwardTile(p);
      if(!leaving && fTile.Texture == "ice")
      {
        SetPlayerPos(p, fTile);
        Ice(p, false); 
      }
      else if(fTile.Transparent == true)
      {
        SetPlayerPos(p, fTile);
      }
    }
    public Tile GetForwardTile(Player p)
    {
      //0=n, 1=s, 2=e, 3=w
      Player tempPlayer = p;
      switch(tempPlayer.Bearing)
      {
        case 1:
        tempPlayer.Y -= 1;
        break;
        case 2:
        tempPlayer.X += 1;
        break;
        case 3:
        tempPlayer.X -= 1;
        break;
        default:
        tempPlayer.Y += 1;
        break;
      }
      Tile target = _db.Map.FirstOrDefault(t=>t.X == tempPlayer.X && t.Y == tempPlayer.Y && t.Z == tempPlayer.Z);
      return target;
    }
    public void SetSpawnPoint(Player p)
    {
      List<Tile> spawnTiles = _db.Map.AsQueryable()
      .Where(t => t.Aux == "spawn").ToList();
      Random rnd = new Random();
      int r = rnd.Next(spawnTiles.Count);
      SetPlayerPos(p, spawnTiles[r]);
    }
    
  }
}

/*
  Door:
  Method =1
  Aux = Id of destination tile, 
  Mud: 
  Method = 2
  Aux = 0, 
  PressurePlateToggle: 
  Method = 3
  Aux = Id of target wall tile, 
  PressurePlateKey:
  Method = 4
  Aux = Id of target wall tile, 
  Ice: 
  Method = 5
  Aux = 0, 
  TrapDoor: 
  Method = 6
  Aux = Id of destination tile, 
  Lava: 
  Method = 7 
  Aux = 0
  Set any tile for respawn's Aux = to "spawn"
*/