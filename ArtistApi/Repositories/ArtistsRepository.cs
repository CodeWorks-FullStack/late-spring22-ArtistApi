using System.Collections.Generic;
using System.Data;
using System.Linq;
using ArtistApi.Models;
using Dapper;

namespace ArtistApi.Repositories
{
  public class ArtistsRepository
  {
    private readonly IDbConnection _db;

    public ArtistsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Artist> Get()
    {
      //   string sql = "SELECT * FROM artists"; DEFAULT NO POPULATE
      //   QUERY == find
      //   return _db.Query<Artist>(sql).ToList(); 


      string sql = @"
      SELECT
        a.*,
        acts.*
      FROM artists a
      JOIN accounts acts ON acts.id = a.creatorId
      ";
      return _db.Query<Artist, Profile, Artist>(sql, (artist, profile) =>
      {
        artist.Creator = profile;
        return artist;
      }).ToList();
    }

    internal Artist Get(int id)
    {
      //   string sql = "SELECT * FROM artists WHERE id = @id";
      //   //   QUERY == find
      //   return _db.QueryFirstOrDefault<Artist>(sql, new { id });

      string sql = @"
      SELECT
        arts.*,
        acts.*
      FROM artists arts
      JOIN accounts acts ON acts.id = arts.creatorId
      WHERE arts.id = @id
      ";
      return _db.Query<Artist, Profile, Artist>(sql, (artist, profile) =>
      {
        artist.Creator = profile;
        return artist;
      }, new { id }).FirstOrDefault();
    }

    internal Artist Create(Artist artistData)
    {
      string sql = @"
      INSERT INTO artists
      (name, dateOfBirth, isAlive, creatorId)
      VALUES
      (@Name, @DateOfBirth, @IsAlive, @CreatorId);
      SELECT LAST_INSERT_ID();
      ";
      //   send to db
      int id = _db.ExecuteScalar<int>(sql, artistData);
      artistData.Id = id;
      return artistData;
    }

    internal void Edit(Artist original)
    {
      string sql = @"
      UPDATE artists
      SET
        name = @Name,
        dateOfBirth = @DateOfBirth,
        isAlive = @IsAlive
      WHERE id = @Id
      ";
      _db.Execute(sql, original);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM artists WHERE id = @id LIMIT 1";
      _db.Execute(sql, new { id });
    }
  }
}