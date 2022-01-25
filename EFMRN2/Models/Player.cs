namespace EFMRN2.Models
{
  public class Player
  {
    public int PlayerId { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }
    public int Bearing { get; set; }
    public string Color { get; set; }
    public bool Transparency { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual Item Item { get; set; }
  }
}