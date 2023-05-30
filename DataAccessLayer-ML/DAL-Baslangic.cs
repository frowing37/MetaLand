using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer_ML;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer_ML
{
	public class DAL_Baslangic
	{
		public static List<Başlangıç> readBaslangic()
		{
			SqlCommand cmd = new SqlCommand("select * from TBL_Başlangıç where ID=1", Context.context);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			List<Başlangıç> b = new List<Başlangıç>();

			if (rd.Read())
			{
				b.Add(new Başlangıç(Convert.ToInt32(rd["BaşlangıçPara"]), Convert.ToInt32(rd["BaşlangıçEşya"]), Convert.ToInt32(rd["BaşlangıçYemek"]), Convert.ToInt32(rd["BaşlangıçX"]), Convert.ToInt32(rd["BaşlangıçY"]), Convert.ToInt32(rd["BaşlangıçGün"])));
			}
			rd.Close();

			return b;
		}
		public static bool UpdateXY(int x,int y)
		{
			SqlCommand cmd = new SqlCommand("update TBL_Başlangıç set BaşlangıçX = @p1 ,BaşlangıçY = @p2 where ID=1", Context.context);
			cmd.Parameters.Add("@p1", x);
			cmd.Parameters.Add("@p2", y);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool IncreaseDay(int day)
		{
			SqlCommand cmd = new SqlCommand("update TBL_Başlangıç set BaşlangıçGün+=@p1 where ID=1", Context.context);
			cmd.Parameters.Add("@p1", day);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool resetDay()
		{
			SqlCommand cmd = new SqlCommand("update TBL_Başlangıç set BaşlangıçGün=1 where ID=1", Context.context);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
