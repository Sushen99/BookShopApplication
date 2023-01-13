using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        public class Category : Controller
        { 
            public IActionResult Index()
            {
                return View();
            }
        }
    }
}
