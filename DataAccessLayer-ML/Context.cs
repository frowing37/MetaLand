using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer_ML
{
	public class Context
	{
		public static SqlConnection context = new SqlConnection(@"Data Source=DESKTOP-N9TUFUP;Initial Catalog=MetaLand0.1;Integrated Security=True");
	}
}
