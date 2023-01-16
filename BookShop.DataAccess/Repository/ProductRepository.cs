using BookShop.DataAccess.Repository.IRepository;
using BookShop.Model;
using BookShopWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
	public class ProductRepository :  Repository<Product>, IProductRepository
	{
		protected readonly ApplicationDbContext _context;
		
		public ProductRepository(ApplicationDbContext context):base(context)
		{
			_context = context;
		}

		public void Update(Product obj)
		{
			// this is having one drwbk, only updating single property , it will update all the property
			//_context.Products.Update(obj);
			var objFromDb = _context.Products.FirstOrDefault(u => u.Id == obj.Id);
			if(objFromDb != null)
			{
				objFromDb.Title = obj.Title;
				objFromDb.ISBN = obj.ISBN;
				objFromDb.Price = obj.Price; ;
				objFromDb.Price50 = obj.Price50;
				objFromDb.ListPrice = obj.ListPrice;
				objFromDb.Price100 = obj.Price100;
				objFromDb.Author = obj.Author;
				objFromDb.Description = obj.Description; 
				objFromDb.Category = obj.Category;
				objFromDb.CategoryId= obj.CategoryId;
				
				if(obj.ImageURL!=null)
				{
					objFromDb.ImageURL = obj.ImageURL;
				}
			}
		}
	}
}
