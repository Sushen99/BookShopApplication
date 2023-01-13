using BookShopWeb.Data;
using BookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryLIst = _context.Categories.ToList();
            return View(objCategoryLIst);
        }


        // GET
        // will fetch model inside the view.cshtml no need to pass
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            // here if we hit create button then it leads to exception need to add validation
            _context.Categories.Add(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
