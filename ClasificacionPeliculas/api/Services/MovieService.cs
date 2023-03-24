
using api.Context;
using ClasificacionPeliculasModel;

namespace api.Services;

public interface IMoviesService : IDatabaseService<Movie, int>
{

}

public class MovieService : IMoviesService
{
  private MoviesContext dbContext;
  public MovieService(MoviesContext dbContext)
  {
    this.dbContext = dbContext;
  }

  public Movie Create(Movie entity)
  {
    dbContext.Movies.Add(entity);
    dbContext.SaveChanges();
    return entity;
  }

  public Movie? Delete(int id)
  {
    Movie? vote = dbContext.Movies.FirstOrDefault(s => s.Id == id);
    if (vote == null) return null;
    dbContext.Movies.Remove(vote);
    vote.VotesNavigation = null;
    dbContext.SaveChanges();
    return vote;
  }

  public List<Movie> GetAll()
  {
    return (
      from m in dbContext.Movies
      select new Movie
      {
        Id = m.Id,
        Title = m.Title,
        ReleaseDate = m.ReleaseDate,
        Duration = m.Duration,
        Director = m.Director,
        Actors = m.Actors,
        Plot = m.Plot,
        Rating = m.Rating,
        Votes = m.Votes,
        PosterUrl = m.PosterUrl,
        ImdbId = m.ImdbId,
        VotesNavigation = null
      }
    ).ToList();
  }

  public Movie? GetOne(int id)
  {
    Movie movie = (
                    from m in dbContext.Movies
                    where m.Id == id
                    select new Movie
                    {
                      Id = m.Id,
                      Title = m.Title,
                      ReleaseDate = m.ReleaseDate,
                      Duration = m.Duration,
                      Director = m.Director,
                      Actors = m.Actors,
                      Plot = m.Plot,
                      Rating = m.Rating,
                      Votes = m.Votes,
                      PosterUrl = m.PosterUrl,
                      ImdbId = m.ImdbId,
                      VotesNavigation = null
                    }
                ).First();
    if (movie == null) return null;
    List<Vote> votes =  dbContext.Votes.Where(vt => vt.MoviesId == movie.Id).Select(x => x).ToList();
    movie.Votes = votes.Count();
    movie.Rating = (movie.Votes > 0) ? (decimal)votes.Select(x => x.Rate).Average() : 0;
    return movie;
  }

  public Movie? Update(Movie entity)
  {
    Movie? movie = dbContext.Movies.FirstOrDefault(s => s.Id == entity.Id);
    if (movie == null) return null;
    movie.Title = entity.Title;
    movie.ReleaseDate = entity.ReleaseDate;
    movie.Duration = entity.Duration;
    movie.Director = entity.Director;
    movie.Actors = entity.Actors;
    movie.Plot = entity.Plot;
    movie.PosterUrl = entity.PosterUrl;
    movie.ImdbId = entity.ImdbId;
    dbContext.Movies.Update(movie);
    dbContext.SaveChanges();
    return movie;
  }
}