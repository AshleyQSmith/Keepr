using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Keep> Get()
    {
      string sql = "SELECT * FROM Keeps WHERE isPrivate = 0;";
      return _db.Query<Keep>(sql);
    }

    internal Keep Create(Keep KeepData)
    {
      string sql = @"
            INSERT INTO keeps
            (userId, name, description, img, isPrivate)
            VALUES
            (@UserId, @Name, @Description, @Img, @IsPrivate);
            SELECT LAST_INSERT_ID()";
      KeepData.Id = _db.ExecuteScalar<int>(sql, KeepData);
      return KeepData;
    }

    internal Keep GetById(int id)
    {
      string sql = "SELECT * FROM keeps WHERE id = @Id";
      return _db.QueryFirstOrDefault<Keep>(sql, new { id });
    }

    internal bool Delete(int id, string userId)
    {
      string sql = "DELETE FROM keeps WHERE id = @Id AND userId = @UserId LIMIT 1";
      int affectedRows = _db.Execute(sql, new { id, userId });
      return affectedRows == 1;
    }

    internal IEnumerable<Keep> GetByUser(string userId)
    {
      string sql = "SELECT * FROM keeps WHERE userId = @UserId";
      return _db.Query<Keep>(sql, new { userId });
    }
  }
}