using Keepr.Models;
using System;
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

    internal string Delete(int id)
    {
      if (_repo.Delete(id))
      {
        return "Deleted!";
      }
      throw new Exception("Invalid id");
    }
  }
}