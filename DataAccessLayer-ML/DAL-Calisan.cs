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
	public class DAL_Calisan
	{
		public static List<Çalışan> GetCalisanList()
		{
			List<Çalışan> calisans = new List<Çalışan>();

			SqlCommand cmd = new SqlCommand("select * from TBL_Çalışan", Context.context);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader dr = cmd.ExecuteReader();

			while(dr.Read())
			{
				calisans.Add(new Çalışan(Convert.ToInt32(dr["ÇalışanID"]), Convert.ToInt32(dr["ÇalıştığıIşletme"]), Convert.ToDateTime(dr["ÇalışanBaşlangıçTarih"]), Convert.ToDateTime(dr["ÇalışanBitişTarih"]), Convert.ToInt32(dr["ÇalışanGünSayısı"]), Convert.ToInt32(dr["ÇalışanGünlükSaati"])));
			}
			dr.Close();

			return calisans;
		}
		public static bool UpdateCalisan(int isletme,DateTime bastarih,DateTime bitistarih,int gunsayisi,int gunluksaat,int calisanid)
		{
			SqlCommand cmd = new SqlCommand("update TBL_Çalışan set ÇalıştığıIşletme=@p1,ÇalışanBaşlangıçTarih=@p2,ÇalışanBitişTarih=@p3,ÇalışanGünSayısı=@p4,ÇalışanGünlükSaati=@p5 where ÇalışanID=@p6", Context.context);
			cmd.Parameters.Add("@p1", isletme);
			cmd.Parameters.Add("@p2", bastarih);
			cmd.Parameters.Add("@p3", bitistarih);
			cmd.Parameters.Add("@p4", gunsayisi);
			cmd.Parameters.Add("@p5", gunluksaat);
			cmd.Parameters.Add("@p6", calisanid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool DeleteCalisan(int id)
		{
			SqlCommand cmd = new SqlCommand("delete TBL_Çalışan where ÇalışanID=@p1");
			cmd.Parameters.Add("@p1", id);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static void payIt(int day)
		{
			List<Çalışan> calisans = new List<Çalışan>();

			SqlCommand cmd = new SqlCommand("select ÇalışanID,İşletmeKullanıcıÜcreti from TBL_Çalışan \n inner join TBL_İşletme on TBL_İşletme.İşletmeID=TBL_Çalışan.ÇalıştığıIşletme", Context.context);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				calisans.Add(new Çalışan(Convert.ToInt32(rd["ÇalışanID"]), Convert.ToInt32(rd["İşletmeKullanıcıÜcreti"])));
			}
			rd.Close();

			SqlCommand cmd2 = new SqlCommand("update TBL_User set UserParaMiktarı += @p1*@p4 where UserID=@p2", Context.context);

			foreach(Çalışan c in calisans)
			{
				cmd2.Parameters.Add("@p1", c.getCalisanMaas());
				cmd2.Parameters.Add("@p2", c.getCalısanID());
				cmd2.Parameters.Add("@p4", day);
				cmd2.ExecuteNonQuery();
				cmd2.Parameters.Clear();
			}
		}
	}
}
