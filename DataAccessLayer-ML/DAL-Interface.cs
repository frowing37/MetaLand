using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer_ML;

namespace DataAccessLayer_ML
{
	public interface DAL_Interface<T>
	{
		void Create(T e);
	    T Get(int id, List<User> Users);
		List<T> GetList();
		void Update(T e);
		void Delete(T e);
	}
}
