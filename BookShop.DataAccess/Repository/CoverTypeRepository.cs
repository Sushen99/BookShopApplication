using BookShop.DataAccess.Repository.IRepository;
using BookShop.Model;
using BookShopWeb.DataAccess;
using BookShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
	public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
		private ApplicationDbContext _context;

		public CoverTypeRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}

		
		void ICoverTypeRepository.Update(CoverType obj)
		{
			_context.CoverTypes.Update(obj);
		}
	}
}
