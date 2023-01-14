using BookShop.DataAccess.Repository.IRepository;
using BookShopWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository
{
	public interface ICategoryRepository : IRepository<Category>
	{
		void Update(Category obj);

		void Save();
	}
}
