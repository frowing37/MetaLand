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
	public class DAL_Market
	{
		public static List<Market> getListMarket()
		{
			List<Market> markets = new List<Market>();
			SqlCommand cmd = new SqlCommand("select MarketID,YiyecekÜcreti,UserName,UserSoyad,İşletmeKapasitesi,İşletmeÇalışanSayısı from TBL_İşletme \n inner join TBL_Market on TBL_Market.MarketID=TBL_İşletme.İşletmeID \n inner join TBL_User on TBL_User.UserID=TBL_İşletme.İşletmeYöneticiID", Context.context);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				markets.Add(new Market(Convert.ToInt32(rd["MarketID"]), Convert.ToInt32(rd["YiyecekÜcreti"]), rd["UserName"].ToString() +" "+ rd["UserSoyad"].ToString(), Convert.ToInt32(rd["İşletmeKapasitesi"]), Convert.ToInt32(rd["İşletmeÇalışanSayısı"])));
			}
			rd.Close();

			return markets;
		}
		public static Market getMarketAttributies(int marketid)
		{
			SqlCommand cmd = new SqlCommand("select İşletmeKullanıcıÜcreti,İşletmeGünlükÇalışanSaat from TBL_İşletme where İşletmeID = @p1", Context.context);
			cmd.Parameters.Add("@p1", marketid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();
			Market m = null;
			while(rd.Read())
			{
				m = new Market(Convert.ToInt32(rd["İşletmeKullanıcıÜcreti"]), Convert.ToInt32(rd["İşletmeGünlükÇalışanSaat"]));
			}
			rd.Close();

			return m;
		}
	}
}
