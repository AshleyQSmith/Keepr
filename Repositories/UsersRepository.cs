using System;
using System.Collections.Generic;
using System.Data;
using Keepr.Models;
using Dapper;

namespace Keepr.Repositories
{
  public class UsersRepository
  {
    private readonly IDbConnection _db;

    public UsersRepository(IDbConnection db)
    {
      _db = db;
    }
    internal User GetUser(string userId)
    {
      string sql = "SELECT * FROM users WHERE userId = @UserId";
      return _db.QueryFirstOrDefault<User>(sql, new { userId });
    }
  }
}