
using System;
using System.Data;
using Dapper;
using Keepr.Models;

namespace Keepr.Repositories
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal VaultKeepViewModel Create(VaultKeepViewModel newVaultKeep)
    {
      string sql = @"
        INSERT INTO vaultkeeps
        (vaultId, keepId, userId)
        VALUES
        (@VaultId, @KeepId, @UserId);
        SELECT LAST_INSERT_ID()";
      newVaultKeep.Id = _db.ExecuteScalar<int>(sql, newVaultKeep);
      return newVaultKeep;
    }

    internal VaultKeepViewModel GetById(int id, string userId)
    {
      string sql = "SELECT * FROM vaultkeeps WHERE id = @Id AND userId = @UserId";
      return _db.QueryFirstOrDefault<VaultKeepViewModel>(sql, new { id, userId });
    }
    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM vaultkeeps WHERE id = @id AND userId = @UserId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }

  }
}