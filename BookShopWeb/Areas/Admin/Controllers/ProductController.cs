using BookShop.DataAccess.Repository.IRepository;
using BookShop.Model;
using BookShopWeb.DataAccess;
using BookShopWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> objProductLIst = _unitOfWork.Product.GetAll();
            return View(objProductLIst);
        }
        

        //GET
        public IActionResult Upsert(int? id)
        {
            // need to handle dropdown for coverType and category.

            Product product = new();
            if (id == null || id == 0)
            {
                //Create Product
                return View(product);
            }
            else
            {
                //update Product
            }
			
            return View(product);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj)
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
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
			//var productFromDb = _context.Product.Find(id);
			var productFromDbFirst = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
			//var productFromDbSingle = _context.Product.SingleOrDefault(u => u.Id == id);



			if (productFromDbFirst == null)
            {
                return NotFound();
            }

            return View(productFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");

        }
    }
}

