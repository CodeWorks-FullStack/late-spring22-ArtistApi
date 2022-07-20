using System.ComponentModel.DataAnnotations;

namespace ArtistApi.Models
{
  public class Artist
  {
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(200)]
    public string Name { get; set; }
    public string CreatorId { get; set; }
    public int? DateOfBirth { get; set; }
    public bool? IsAlive { get; set; }

    // NOTE C# VIRTUAL this is not in the DB
    public Profile Creator { get; set; }
  }
}