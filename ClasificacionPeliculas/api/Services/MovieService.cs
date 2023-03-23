
using api.Context;
using ClasificacionPeliculasModel;

namespace api.Services;

public class MovieService : IDatabaseService<Movie, int>
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
    dbContext.SaveChanges();
    return vote;
  }

  public List<Movie> GetAll()
  {
    return dbContext.Movies.ToList();
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
                      ImdbId = m.ImdbId
                    }
                ).First();
    if(movie == null) return null;
    movie.VotesNavigation = dbContext.Votes.Where(vt => vt.MoviesId == movie.Id).Select(x => x).ToList();
    movie.Votes = movie.VotesNavigation.Count();
    movie.Rating = (movie.Votes > 0) ? (decimal)movie.VotesNavigation.Select(x => x.Rate).Average() : 0;
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