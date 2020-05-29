using Keepr.Models;
using Keepr.Repositories;

namespace Keepr.Services
{
  public class UsersService
  {
    private readonly UsersRepository _repo;

    public UsersService(UsersRepository repo)
    {
      _repo = repo;
    }
    public User GetUser(string userId)
    {
      return _repo.GetUser(userId);
    }
  }
}