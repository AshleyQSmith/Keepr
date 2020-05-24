using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    //NOTE needs to be passing in userID
    // internal IEnumerable<Vault> Get()
    // {
    //   // string sql = "SELECT * FROM Vaults WHERE 
    //   // userId - userId"
    // }


    // internal Vault Create(Vault VaultData)
    // {

    // }
  }
}