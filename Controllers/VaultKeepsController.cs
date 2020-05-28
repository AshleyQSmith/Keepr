using Microsoft.AspNetCore.Mvc;
using Keepr.Services;
using Keepr.Models;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authorization;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsService _vks;

    public VaultKeepsController(VaultKeepsService vks)
    {
      _vks = vks;
    }

    [HttpPost]
    [Authorize]
    public ActionResult<VaultKeepViewModel> Create([FromBody] VaultKeepViewModel newVaultKeep)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in.");
        }
        newVaultKeep.UserId = user.Value;
        return Ok(_vks.Create(newVaultKeep));
      }
      catch (System.Exception)
      {

        throw;
      }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in.");
        }
        string userId = user.Value;
        return Ok(_vks.Delete(id, userId));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}