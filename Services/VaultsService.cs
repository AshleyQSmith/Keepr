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


    // public IEnumerable<Vault> Get()
    // {
    //   //NOTE NEEDS TO BE PASSING IN USER ID
    //   return _repo.Get();
    // }
  }
}