
using api.Context;
using ClasificacionPeliculasModel;

namespace api.Services;

public class VoteService : IDatabaseService<Vote, int>
{
  private MoviesContext dbContext;
  public VoteService(MoviesContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public Vote Create(Vote entity)
  {
    entity.RowCreationTime = DateTime.Now;
    dbContext.Votes.Add(entity);
    dbContext.SaveChanges();
    return entity;
  }

  public Vote? Delete(int id)
  {
    Vote? vote = dbContext.Votes.FirstOrDefault(s => s.Id == id);
    if (vote == null) return null;
    dbContext.Votes.Remove(vote);
    dbContext.SaveChanges();
    return vote;
  }

  public List<Vote> GetAll()
  {
    return dbContext.Votes.ToList();
  }

  public Vote? GetOne(int id)
  {
    return dbContext.Votes.FirstOrDefault(s => s.Id == id);
  }

  public Vote? Update(Vote entity)
  {
    Vote? vote = dbContext.Votes.FirstOrDefault(s => s.Id == entity.Id);
    if (vote == null) return null;
    vote.PiId = entity.PiId;
    vote.MoviesId = entity.MoviesId;
    vote.Rate = entity.Rate;
    dbContext.Votes.Update(vote);
    dbContext.SaveChanges();
    return vote;
  }
}