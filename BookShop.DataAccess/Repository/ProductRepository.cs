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
			_context.Products.Update(obj);
		}
	}
}
