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
      _db=db;
    }
  }
  [HttpGet]
  public async Task<ActionResult<Tile>> Get(int x, int y, int z)
  {
    Tile target = _db.Map.AsQueryable().Where(t=>t.x == x && t.y == y && t.z == z);
    return 
  }
}