
using System;
using System.Security.Claims;
using Keepr.Models;
using Keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Keepr.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class UsersController : ControllerBase
  {
    private readonly UsersService _us;

    public UsersController(UsersService us)
    {
      _us = us;
    }

    [HttpGet]
    [Authorize]
    public ActionResult<User> GetUser()
    {
      try
      {
        Claim user = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
        if (user == null)
        {
          throw new Exception("Must be logged in.");
        }
        string userId = user.Value;
        return Ok(_us.GetUser(userId));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}