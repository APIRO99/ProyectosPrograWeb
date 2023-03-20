using ClasificacionPeliculas.Context;
using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;

namespace ClasificacionPeliculas.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            MoviesContext _moviesContext = new MoviesContext();
            IEnumerable<Category> categories = (from c in _moviesContext.Categories
                                                //join mc in _moviesContext.Moviescategories on c.Id equals mc.CategoryId
                                                //where c.Id == 0
                                                select new Category { Id = c.Id, Name = c.Name}).OrderBy(s => s.Name).ToList();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(string Name)
        {
            MoviesContext _moviesContext = new MoviesContext();
            Category category = new Category
            {
                Name = Name
            };
            _moviesContext.Categories.Add(category);
            _moviesContext.SaveChanges();
            Category categoryResult = new Category
            {
                Name = Name,
                Id = category.Id
            };
            ViewBag.Resultado = true;
            return View(categoryResult);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            MoviesContext _moviesContext = new MoviesContext();
            Category category = _moviesContext.Categories.FirstOrDefault(s => s.Id == id);
            Category categoryResult = new Category
            {
                Id = category.Id,
                Name = category.Name,
            };
            return View(categoryResult);
        }
        [HttpPost]
        public IActionResult Edit(int id, string Name)
        {
            MoviesContext _moviesContext = new MoviesContext();
            Category category = _moviesContext.Categories.FirstOrDefault(s => s.Id == id);
            category.Name = Name;
            _moviesContext.Categories.Update(category);
            _moviesContext.SaveChanges();
            Category categoryResult = new Category
            {
                Name = Name,
                Id = category.Id
            };
            ViewBag.Resultado = true;
            return View(categoryResult);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            MoviesContext _moviesContext = new MoviesContext();
            Category category = _moviesContext.Categories.FirstOrDefault(s => s.Id == id);
            Category categoryResult = new Category
            {
                Id = category.Id,
                Name = category.Name,
            };
            return View(categoryResult);
        }
    }
}
