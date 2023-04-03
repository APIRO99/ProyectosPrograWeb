
using backend.Context;
using backend.Models;

namespace backend.Services;

public interface IUserService: IBaseCrud<User, int> { }

public class UserService : IUserService
{
  private readonly PropiedadesDelBosqueContext dbContext = new PropiedadesDelBosqueContext();

  public User Create(User entity)
  {
    dbContext.Users.Add(entity);
    dbContext.SaveChanges();
    return entity;
  }

  public User? Delete(int id)
  {
    User? User = dbContext.Users.Find(id);
    if (User == null) return null;
    dbContext.Users.Remove(User);
    dbContext.SaveChanges();
    return User;
  }

  public List<User> GetAll()
  {
    return dbContext.Users.ToList();
  }

  public User? GetOne(int id)
  {
    return (
      from c in dbContext.Users
      where c.Id == id
      select new User() {
        Id = c.Id,
        Name = c.Name,
        Email = c.Email,
        Password = c.Password,
        CreatedAt = DateTime.Now,
      }
    ).FirstOrDefault();
  }

  public User? Update(User entity)
  {
    User? User = dbContext.Users.Find(entity.Id);
    if (User == null) return null;
    User.Name = entity.Name;
    User.Email = entity.Email;
    User.Password = entity.Password;
    dbContext.SaveChanges();
    return User;
  }
}
