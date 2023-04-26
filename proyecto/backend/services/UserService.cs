
using backend.Context;
using backend.Models;
using backend.Utils;

namespace backend.Services;

public interface IUserService: IBaseCrud<User, int> { 
  public User? GetOneByUsername(string username);
}

public class UserService : IUserService
{
  private readonly PropiedadesDelBosqueContext dbContext = new PropiedadesDelBosqueContext();

  private readonly IEncode encode;
  public UserService(IEncode _encode) => this.encode = _encode;

  public User Create(User entity)
  {
    entity.CreatedAt = DateTime.Now;
    entity.Password = encode.Encriptar(entity.Password);
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
    return (
      from c in dbContext.Users
      select new User() {
        Id = c.Id,
        Username = c.Username,
        Name = c.Name,
        Email = c.Email,
        Password = encode.Desencriptar(c.Password),
        CreatedAt = c.CreatedAt,
      }
    ).ToList();
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
        Password = encode.Desencriptar(c.Password),
        CreatedAt = c.CreatedAt,
      }
    ).FirstOrDefault();
  }

  public User? GetOneByUsername(string username)
  {
    return (
      from c in dbContext.Users
      where c.Username == username
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
    User.Password = encode.Encriptar(entity.Password);
    User.Username = entity.Username;
    dbContext.SaveChanges();

    User.Password = encode.Desencriptar(User.Password);
    return User;
  }
}
