using ClasificacionPeliculas.Context;
using ClasificacionPeliculasModel;
using Microsoft.AspNetCore.Mvc;

namespace ClasificacionPeliculas.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService cs;

        public CategoriesController(ICategoriesService cs) {
            this.cs = cs;
        }

        public async Task<ActionResult> Index()
        {
            IEnumerable<Category> categories = await cs.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(string Name)
        {
            Category category = new Category() { Name = Name };
            await cs.CreateCategory(category);
             return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            Category category = await cs.GetCategory(id);
            return View(category);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(int id, string Name)
        {
            Category category = new Category() { Id = id, Name = Name };
            await cs.UpdateCategory(category);
             return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            Category categoryResult = await cs.GetCategory(id);
            return View(categoryResult);
        }
    }
}
