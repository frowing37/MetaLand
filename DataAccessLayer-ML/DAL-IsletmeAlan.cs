using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer_ML;

namespace DataAccessLayer_ML
{
	public class DAL_IsletmeAlan
	{
		public static List<İşletmeAlan> getAreaList()
		{
			List<İşletmeAlan> areas = new List<İşletmeAlan>();

			SqlCommand cmd = new SqlCommand("select *,İşletmeTürü from TBL_İşletmeAlan \n inner join TBL_İşletme on TBL_İşletme.İşletmeID=TBL_İşletmeAlan.İşletmeID", Context.context);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				areas.Add(new İşletmeAlan(Convert.ToInt32(rd["AlanID"]), Convert.ToBoolean(rd["AlanTürü"]), Convert.ToInt32(rd["AlanSahibi"]), Convert.ToInt32(rd["İşletmeID"]), Convert.ToInt32(rd["İşletmeTürü"])));
			}
			rd.Close();

			return areas;
		}
		public static List<İşletmeAlan> getBusinessAreas(int isletmeid)
		{
			List<İşletmeAlan> alan = new List<İşletmeAlan>();

			SqlCommand cmd = new SqlCommand("select * from TBL_İşletmeAlan where İşletmeID=@p1", Context.context);
			cmd.Parameters.Add("@p1", isletmeid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				alan.Add(new İşletmeAlan(rd["AlanID"].ToString(),Convert.ToInt32(rd["AlanID"]), Convert.ToBoolean(rd["AlanTürü"]), Convert.ToInt32(rd["AlanSahibi"]), Convert.ToInt32(rd["İşletmeID"])));
			}
			rd.Close();

			return alan;
		}
		public static List<İşletmeAlan> getBusinessAreasbyUser(int userid)
		{
			List<İşletmeAlan> alan = new List<İşletmeAlan>();

			SqlCommand cmd = new SqlCommand("select * from TBL_İşletmeAlan where AlanSahibi=@p1", Context.context);
			cmd.Parameters.Add("@p1", userid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while (rd.Read())
			{
				alan.Add(new İşletmeAlan(rd["AlanID"].ToString(), Convert.ToInt32(rd["AlanID"]), Convert.ToBoolean(rd["AlanTürü"]), Convert.ToInt32(rd["AlanSahibi"]), Convert.ToInt32(rd["İşletmeID"])));
			}
			rd.Close();

			return alan;
		}
		public static bool buyArea1(int userid,int area1,int area2)
		{
			SqlCommand cmd = new SqlCommand("Update TBL_İşletmeAlan set AlanSahibi=@p1 where AlanID=@p2", Context.context);
			SqlCommand cmd2 = new SqlCommand("Update TBL_İşletmeAlan set AlanSahibi=@p1 where AlanID=@p3", Context.context);
			cmd.Parameters.Add("@p1", userid);
			cmd2.Parameters.Add("@p1", userid);
			cmd.Parameters.Add("@p2", area1);
			cmd2.Parameters.Add("@p3", area2);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			if (cmd2.Connection.State != ConnectionState.Open)
			{
				cmd2.Connection.Open();
			}

			bool a = cmd.ExecuteNonQuery() > 0;
			bool b = cmd2.ExecuteNonQuery() > 0;

			return (a & b);
		}
		public static bool buyArea2(int userid, int area1)
		{
			SqlCommand cmd = new SqlCommand("Update TBL_İşletmeAlan set AlanSahibi=@p1 where AlanID=@p2", Context.context);
			cmd.Parameters.Add("@p1", userid);
			cmd.Parameters.Add("@p2", area1);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool convertArea(int area1,int userid,int isletmetur)
		{
			SqlCommand cmd = new SqlCommand("insert into TBL_İşletme (İşletmeTürü,İşletmeYöneticiID) values (@p1,@p2)", Context.context);
			cmd.Parameters.Add("@p1", isletmetur);
			cmd.Parameters.Add("@p2", userid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			cmd.ExecuteNonQuery();

			SqlCommand cmd3 = new SqlCommand("select * from TBL_İşletme where İşletmeYöneticiID=@p1",Context.context);
			cmd3.Parameters.Add("@p1", userid);

			SqlDataReader rd = cmd3.ExecuteReader();
			İşletme i = null;

			while(rd.Read())
			{
				i = new İşletme(Convert.ToInt32(rd["İşletmeID"]));
			}
			rd.Close();

			SqlCommand cmd2 = new SqlCommand("update TBL_İşletmeAlan set İşletmeID=@p1,AlanTürü=1 where AlanID=@p2", Context.context);
			cmd2.Parameters.Add("@p1", i.getID());
			cmd2.Parameters.Add("@p2", area1);

			switch(isletmetur)
			{
				case 1:
					SqlCommand cmd5 = new SqlCommand("insert into TBL_Market (MarketID)  values (@p1)", Context.context);
					cmd5.Parameters.Add("@p1", i.getID());
					cmd5.ExecuteNonQuery();
					break;
				case 2:
					SqlCommand cmd6 = new SqlCommand("insert into TBL_Mağaza (MagazaID) values (@p1)", Context.context);
					cmd6.Parameters.Add("@p1", i.getID());
					cmd6.ExecuteNonQuery();
					break;
				case 3:
					SqlCommand cmd7 = new SqlCommand("insert into TBL_Emlak (EmlakID) values (@p1)", Context.context);
					cmd7.Parameters.Add("@p1", i.getID());
					cmd7.ExecuteNonQuery();
					break;
			}


			return cmd2.ExecuteNonQuery() > 0;
		}
	}
}
