using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ArtistApi.Models;
using ArtistApi.Services;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
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
    public ActionResult<Artist> Get(int id)
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
    [Authorize]
    public async Task<ActionResult<Artist>> Create([FromBody] Artist artistData)
    {
      try
      {
        // NOTE req.userInfo
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        artistData.CreatorId = userInfo.Id;
        Artist newArtist = _artServ.Create(artistData);
        newArtist.Creator = userInfo;
        return Ok(newArtist);

      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Edit
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Artist>> EditAsync(int id, [FromBody] Artist artistData)
    {
      try
      {
        // TODO add creatorID
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        artistData.Id = id;
        artistData.CreatorId = userInfo.Id;
        Artist update = _artServ.Edit(artistData);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    // Delete
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<Artist>> DeleteAsync(int id)
    {
      try
      {
        // TODO add creatorID
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Artist deletedArtist = _artServ.Delete(id, userInfo.Id);
        return Ok(deletedArtist);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}