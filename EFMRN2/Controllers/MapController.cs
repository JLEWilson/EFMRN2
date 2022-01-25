using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using EFMRN2.Models;

namespace EFMRN2.Controllers
{
    public class MapController : Controller
    {
        private readonly EFMRN2Context _db;

        public MapController(EFMRN2Context db)
        {
            _db = db;
        }
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
            break;
            default:
            break;
          }

          
        }
        

        //A route to run tile methods

        //A route to get new map tiles( When the player moves north get the new north row.)
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
          p.X = t.X;
          p.Y = t.Y;
          p.Z = t.Z;
        }
        public void Door(Player p)
        {
          Tile targetA = GetPlayerTile(p);
          int i = Int32.Parse(targetA.Aux);
          Tile target = GetTileById(i);
          SetPlayerPos(p,target);
        }
    }

    
}
