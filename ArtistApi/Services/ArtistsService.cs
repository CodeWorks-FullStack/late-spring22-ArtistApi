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
      return _repo.Create(artistData);
    }

    internal Artist Edit(Artist artistData)
    {
      Artist original = Get(artistData.Id);
      //   if (artistData.CreatorId != original.CreatorId)
      //   {
      //     throw new Exception("You cannot edit that")
      //   }
      original.Name = artistData.Name ?? original.Name;
      original.DateOfBirth = artistData.DateOfBirth ?? original.DateOfBirth;
      original.IsAlive = artistData.IsAlive ?? original.IsAlive;

      // save changes
      _repo.Edit(original);

      return original;
    }

    internal Artist Delete(int id, string userId)
    {
      Artist original = Get(id);
      //   if (userId != original.CreatorId)
      //   {
      //     throw new Exception("You cannot edit that")
      //   }

      _repo.Delete(id);

      return original;
    }
  }
}