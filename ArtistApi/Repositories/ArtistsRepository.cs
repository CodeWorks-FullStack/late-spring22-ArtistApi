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
      string sql = "SELECT * FROM artists";
      //   QUERY == find
      return _db.Query<Artist>(sql).ToList();
    }

    internal Artist Get(int id)
    {
      string sql = "SELECT * FROM artists WHERE id = @id";
      //   QUERY == find
      return _db.QueryFirstOrDefault<Artist>(sql, new { id });
    }
  }
}