using Microsoft.AspNetCore.Mvc;
using Keepr.Services;
using Keepr.Models;
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
    public ActionResult<VaultKeepViewModel> Create([FromBody] VaultKeepViewModel newVaultKeep)
    {
      try
      {
        return Ok(_vks.Create(newVaultKeep));
      }
      catch (System.Exception)
      {

        throw;
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_vks.Delete(id));
      }
      catch (System.Exception error)
      {
        return BadRequest(error.Message);
      }
    }

  }
}