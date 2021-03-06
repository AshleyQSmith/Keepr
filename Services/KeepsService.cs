using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class KeepsService
  {
    private readonly KeepsRepository _repo;
    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }
    // gets all public keeps
    public IEnumerable<Keep> Get()
    {
      return _repo.Get();
    }

    public Keep Create(Keep newKeep)
    {
      return _repo.Create(newKeep);
    }

    public Keep GetById(int id)
    {
      Keep foundKeep = _repo.GetById(id);
      if (foundKeep == null)
      {
        throw new Exception("Invalid Keep Id");
      }
      return foundKeep;
    }

    internal object Delete(int id, string userId)
    {
      Keep foundKeep = GetById(id);
      if (foundKeep.UserId != userId)
      {
        throw new Exception("This is not your keep!");
      }
      if (_repo.Delete(id, userId))
      {
        return "Deleted!";
      }
      throw new Exception("errrr");
    }

    internal IEnumerable<Keep> GetByUser(string userId)
    {
      return _repo.GetByUser(userId);
    }

    internal IEnumerable<VaultKeepViewModel> GetKeepsByVaultId(int id)
    {
      return _repo.GetKeepsByVaultId(id);
    }

    internal Keep Edit(int id, Keep updatedKeep)
    {
      Keep foundKeep = GetById(id);
      foundKeep.IsPrivate = updatedKeep.IsPrivate;
      foundKeep.Views = updatedKeep.Views;
      foundKeep.Keeps = updatedKeep.Keeps;
      foundKeep.Shares = updatedKeep.Shares;
      return _repo.Edit(foundKeep);
    }
  }
}