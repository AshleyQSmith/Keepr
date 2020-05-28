using System;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultKeepsService
  {
    private readonly VaultKeepsRepository _repo;

    public VaultKeepsService(VaultKeepsRepository repo)
    {
      _repo = repo;
    }

    internal VaultKeepViewModel Create(VaultKeepViewModel newvVaultKeep)
    {
      return _repo.Create(newvVaultKeep);
    }

    public VaultKeepViewModel GetById(int id, string userId)
    {
      VaultKeepViewModel foundVaultKeep = _repo.GetById(id, userId);
      if (foundVaultKeep == null)
      {
        throw new Exception("Invalid Id");
      }
      if (foundVaultKeep.UserId != userId)
      {
        throw new Exception("This is not yours!");
      }
      return foundVaultKeep;
    }


    internal string Delete(int id, string userId)
    {
      VaultKeepViewModel foundVaultKeep = GetById(id, userId);
      if (_repo.Delete(id, userId))
      {
        return "Deleted!";
      }
      throw new Exception("Invalid id");
    }
  }
}