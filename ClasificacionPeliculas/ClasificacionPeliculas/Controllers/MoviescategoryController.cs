using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ClasificacionPeliculas.Controllers
{
    public class MoviescategoryController : Controller
    {
        private readonly IMoviesService ms;
        private readonly ICategoriesService cs;
        public IMoviescategoriesService mcs;
        public MoviescategoryController(IMoviescategoriesService mcs, IMoviesService ms, ICategoriesService cs) {
            this.mcs = mcs;
            this.ms = ms;
            this.cs = cs;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Moviescategory> moviescategories = await mcs.GetMoviescategories();
            return View(moviescategories);
        }

        public async Task<IActionResult> Create()
        {
            IEnumerable<Movie> movies = await ms.GetMovies();
            IEnumerable<Category> categories = await cs.GetCategories();
            
            Moviescategory moviescategory = new Moviescategory();
            moviescategory.Categories = categories.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();
            moviescategory.Movies = movies.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Title
            }).ToList();

            moviescategory.Movie = await ms.GetMovie(movies.First().Id);
            return View(moviescategory);
        }
        [HttpPost]
        public async Task<IActionResult> Create(int MovieId, int CategoryId)
        {
            Moviescategory moviescategory = new Moviescategory { MovieId = MovieId, CategoryId = CategoryId };
            await mcs.CreateMoviescategory(moviescategory);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Moviescategory moviescategory = await mcs.GetMoviescategory(id);
            Moviescategory CPMmoviescategory = new Moviescategory
            {
                CategoryId = moviescategory.CategoryId,
                MovieId = moviescategory.MovieId,
                Id = moviescategory.Id
            };
            IEnumerable<Movie> movies = await ms.GetMovies();
            IEnumerable<Category> categories = await cs.GetCategories();

            CPMmoviescategory.Categories = categories.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Name,
                Selected = (s.Id == CPMmoviescategory.CategoryId)
            }).ToList();
            ViewBag.Movies = movies.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Title,
                Selected = (s.Id == CPMmoviescategory.MovieId)
            }).ToList();
            return View(CPMmoviescategory);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int Id, int MovieId, int CategoryId)
        {
            Moviescategory entity = new Moviescategory(){
                Id = Id,
                MovieId = MovieId,
                CategoryId = CategoryId
            };
            await mcs.UpdateMoviescategory(entity);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
            Moviescategory moviescategory = await mcs.GetMoviescategory(id);
            Moviescategory CPMmoviescategory = new Moviescategory
            {
                CategoryId = moviescategory.CategoryId,
                MovieId = moviescategory.MovieId,
                Id = moviescategory.Id
            };
            IEnumerable<Movie> movies = await ms.GetMovies();
            IEnumerable<Category> categories = await cs.GetCategories();

            CPMmoviescategory.Categories = categories.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Name,
                Selected = (s.Id == CPMmoviescategory.CategoryId)
            }).ToList();
            CPMmoviescategory.Movies = movies.Select(s => new SelectListItem()
            {
                Value = s.Id.ToString(),
                Text = s.Title,
                Selected = (s.Id == CPMmoviescategory.MovieId)
            }).ToList();
            return View(CPMmoviescategory);
        }

        
    }
}
