using System;
using System.Collections.Generic;
using ArtistApi.Models;
using ArtistApi.Repositories;

namespace ArtistApi.Services
{
  public class ArtistsService
  {
    private readonly ArtistsRepository _repo;

    public ArtistsService(ArtistsRepository repo)
    {
      _repo = repo;
    }

    internal List<Artist> Get()
    {
      return _repo.Get();
    }

    internal Artist Get(int id)
    {
      // get it....
      Artist found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Id");
      }
      return found;
    }

    internal Artist Create(Artist artistData)
    {
      throw new NotImplementedException();
    }

    internal Artist Edit(Artist artistData)
    {
      throw new NotImplementedException();
    }

    internal Artist Delete(string id)
    {
      throw new NotImplementedException();
    }
  }
}