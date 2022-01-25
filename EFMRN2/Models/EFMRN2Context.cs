using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFMRN2.Models
{
  public class EFMRN2Context : IdentityDbContext<ApplicationUser>
  {



    public DbSet<Tile> Map {get;set;}
    public DbSet<Player> Players { get; set; }
    public DbSet<ApplicationUser> GameUsers {get;set;}
    public EFMRN2Context(DbContextOptions options) : base(options) {}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);
      builder.Entity<Tile>().HasData(
        new Tile {TileId=1, Texture = "pain", Transparent=true},
        new Tile {TileId=2,Texture = "despare", Transparent=false},
        new Tile {TileId=3,Texture = "Time", Transparent=false},
        new Tile {TileId=4,Texture = "sour", Transparent=true}
      );
    }
  }
}