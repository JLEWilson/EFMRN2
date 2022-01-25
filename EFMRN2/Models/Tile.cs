namespace EFMRN2.Models
{
  public class Tile
  {
    public int TileId { get;set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public string Aux {get;set;}
    public bool Transparent { get; set; }
    public string Texture { get; set; }
    public int Method { get; set; }
  }
}