using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataAccess.Repository.IRepository
{
	public interface IRepository<T>:where T:class
	{
		IEnumerable<T> GetAll();

		void Add(T entity);
		
		T GeyFirstOrDefault(Expression<Func<T, bool>> filter);

		void Remove(T entity);

		void RemoveRange(IEnumerable<T> entity);

	}
}
