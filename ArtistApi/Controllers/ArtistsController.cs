using System;
using System.Collections.Generic;
using ArtistApi.Models;
using ArtistApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArtistApi.Controllers
{


  [ApiController]
  [Route("api/[controller]")]
  public class ArtistsController : ControllerBase
  {
    private readonly ArtistsService _artServ;

    public ArtistsController(ArtistsService artServ)
    {
      _artServ = artServ;
    }

    // GetAll
    [HttpGet]
    public ActionResult<List<Artist>> Get()
    {
      try
      {
        List<Artist> artists = _artServ.Get();
        return Ok(artists);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // GetById
    [HttpGet("{id}")]
    public ActionResult<Artist> Get(string id)
    {
      try
      {
        Artist artist = _artServ.Get(id);
        return Ok(artist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


    // Create
    [HttpPost]
    public ActionResult<Artist> Create([FromBody] Artist artistData)
    {
      try
      {
        // TODO add creatorId
        Artist newArtist = _artServ.Create(artistData);
        return Ok(newArtist);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Edit
    [HttpPut("{id}")]
    public ActionResult<Artist> Edit(string id, [FromBody] Artist artistData)
    {
      try
      {
        // TODO add creatorID
        artistData.Id = id;
        Artist update = _artServ.Edit(artistData);
        return Ok();
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Delete
    [HttpDelete("{id}")]
    public ActionResult<Artist> Delete(string id)
    {
      try
      {
        // TODO add creatorID
        Artist deletedArtist = _artServ.Delete(id);
        return Ok(deletedArtist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}