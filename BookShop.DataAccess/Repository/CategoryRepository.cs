using BookShop.DataAccess.Repository.IRepository;
using BookShopWeb.DataAccess;
using BookShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
	public class CategoryRepository : Repository<Category>, ICategoryRepository
	{
		private ApplicationDbContext _context;

		public CategoryRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		
		void ICategoryRepository.Update(Category obj)
		{
			_context.Categories.Update(obj);
		}
	}
}
