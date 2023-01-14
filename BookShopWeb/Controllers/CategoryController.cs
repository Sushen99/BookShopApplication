using BookShop.DataAccess.Repository.IRepository;
using BookShopWeb.DataAccess;
using BookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _context;

        public CategoryController(ICategoryRepository context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryLIst = _context.GetAll();
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
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(obj);
                _context.Save();
                TempData["success"] = "Category created successfully";// tempdata
                return RedirectToAction("Index");
            }
            return View(obj);
        }


		//GET
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			//var categoryFromDb = _context.Categories.Find(id);
			var categoryFromDbFirst = _context.GetFirstOrDefault(u => u.Id == id);
			//var categoryFromDbSingle = _context.Categories.SingleOrDefault(u => u.Id == id);

			if (categoryFromDbFirst == null)
			{
				return NotFound();
			}

			return View(categoryFromDbFirst);
		}

		//POST
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
			}
			if (ModelState.IsValid)
			{
				_context.Update(obj);
				_context.Save();
				TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index");
			}
			return View(obj);
		}
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //var categoryFromDb = _context.Categories.Find(id);
            var categoryFromDbFirst = _context.GetFirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _context.Categories.SingleOrDefault(u => u.Id == id);



            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _context.GetFirstOrDefault(u=>u.Id ==id);
            if (obj == null)
            {
                return NotFound();
            }

            _context.Remove(obj);
            _context.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

