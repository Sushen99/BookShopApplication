using BookShop.DataAccess.Repository.IRepository;
using BookShop.Model;
using BookShopWeb.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _context;

		public UnitOfWork(ApplicationDbContext context)
		{
			_context = context;
			Category = new CategoryRepository(_context);
            CoverType = new CoverTypeRepository(_context);
			Product = new ProductRepository(_context);
		}

		public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
		public IProductRepository Product { get; private set; }

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
