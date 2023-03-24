
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
    if (vote.Movies != null) vote.Movies.VotesNavigation = null;
    if (vote.Pi != null) vote.Pi.Votes = null;
    return vote;
  }

  public List<Vote> GetAll()
  {
    List<Vote> votes = (from v in dbContext.Votes
                        join pi in dbContext.PersonalInformations on v.PiId equals pi.Id
                        join mo in dbContext.Movies on v.MoviesId equals mo.Id
                        select new Vote
                        {
                          Id = v.Id,
                          PiId = v.PiId,
                          MoviesId = v.MoviesId,
                          Rate = v.Rate,
                          RowCreationTime = v.RowCreationTime,
                          Movies = new Movie()
                          {
                            Title = mo.Title,

                          },
                          Pi = new PersonalInformation()
                          {
                            Name = pi.Name
                          }
                        }).ToList();
    return votes;
  }

  public Vote? GetOne(int id)
  {
    return
    (from v in dbContext.Votes
     join pi in dbContext.PersonalInformations on v.PiId equals pi.Id
     join mo in dbContext.Movies on v.MoviesId equals mo.Id
     where v.Id == id
     select new Vote
     {
       Id = v.Id,
       PiId = v.PiId,
       MoviesId = v.MoviesId,
       Rate = v.Rate,
       RowCreationTime = v.RowCreationTime,
       Movies = new Movie()
       {
         Title = mo.Title,
         Id = mo.Id
       },
       Pi = new PersonalInformation()
       {
         Name = pi.Name,
         Id = pi.Id
       }
     }).FirstOrDefault();
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
    if (vote.Movies != null) vote.Movies.VotesNavigation = null;
    if (vote.Pi != null) vote.Pi.Votes = null;
    return vote;
  }
}