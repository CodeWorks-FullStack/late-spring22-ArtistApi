namespace ArtistApi.Models
{
  public class Artist
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int DateOfBirth { get; set; }
    public bool IsAlive { get; set; }
  }
}