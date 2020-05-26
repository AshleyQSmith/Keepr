using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;
    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    public Vault Create(Vault newVault)
    {
      return _repo.Create(newVault);
    }

    public IEnumerable<Vault> GetByUser(string userId)
    {
      return _repo.GetByUser(userId);
    }

    public Vault GetById(int id)
    {
      Vault foundVault = _repo.GetById(id);
      if (foundVault == null)
      {
        throw new Exception("Invalid Id");
      }
      return foundVault;
    }

    internal object Delete(int id, string userId)
    {
      Vault foundVault = GetById(id);
      if (foundVault.UserId != userId)
      {
        throw new Exception("This is not your vault!");
      }
      if (_repo.Delete(id, userId))
      {
        return "Deleted!";
      }
      throw new Exception("errrrr");
    }
  }
}