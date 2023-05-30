using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer_ML;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel.Design;

namespace DataAccessLayer_ML
{
	public class DAL_User
	{
		public static bool Create(User e)
		{

			SqlCommand cmd = new SqlCommand("insert into TBL_User (UserName, UserSoyad, UserŞifre) values (@p1,@p2,@p3)", Context.context);
			cmd.Parameters.Add("@p1", e.displayAd);
			cmd.Parameters.Add("@p2", e.displaySoyad);
			cmd.Parameters.Add("@p3", e.displayŞifre);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;

		}
		public void Delete(User e)
		{
			
		}
		public User Get(int id,List<User> Users)
		{
			return null;
		}
		public static List<User> GetList()
		{
			List<User> Users = new List<User>();
			SqlCommand cmd = new SqlCommand("select * from TBL_User",Context.context);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				User ex = new User(Convert.ToInt32(rd["UserID"]),rd["UserName"].ToString(),rd["UserSoyad"].ToString(),rd["UserŞifre"].ToString(),Convert.ToInt32(rd["UserYemekMiktarı"]), Convert.ToInt32(rd["UserEşyaMiktarı"]), Convert.ToInt32(rd["UserParaMiktarı"]), Convert.ToDateTime(rd["OyunBaşlangıçTarihi"]), Convert.ToBoolean(rd["Admin"]), Convert.ToBoolean(rd["ÇalışmaDurumu"]));
				Users.Add(ex);
			}
			rd.Close();

			return Users;
		}
		public static bool UpdateDefault(string columnName,string defaultValue)
		{
			SqlCommand cmd = new SqlCommand("ALTER TABLE TBL_User \n ALTER COLUMN @p2 SET DEFAULT @p3", Context.context);
			cmd.Parameters.Add("@p2", columnName);
			cmd.Parameters.Add("@p3", Convert.ToInt32(defaultValue));

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool UpdateUser(int ID,string Ad,string Soyad,string Şifre,int Yemek,int Para,int Eşya,DateTime Tarih,bool Admin)
		{
			SqlCommand cmd = new SqlCommand("Update TBL_User set UserName=@p1,UserSoyad=@p2,UserŞifre=@p3,UserYemekMiktarı=@p4,UserEşyaMiktarı=@p5,UserParaMiktarı=@p6,OyunBaşlangıçTarihi=@p7,Admin=@p8 where UserID=@p9", Context.context);
			cmd.Parameters.Add("@p1", Ad);
			cmd.Parameters.Add("@p2", Soyad);
			cmd.Parameters.Add("@p3", Şifre);
			cmd.Parameters.Add("@p4", Yemek);
			cmd.Parameters.Add("@p5", Para);
			cmd.Parameters.Add("@p6", Eşya);
			cmd.Parameters.Add("@p7", Tarih);
			cmd.Parameters.Add("@p8", Admin);
			cmd.Parameters.Add("@p9", ID);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool DeleteUser(int id)
		{
			SqlCommand cmd = new SqlCommand("delete from TBL_User where UserID=@p1", Context.context);
			cmd.Parameters.Add("@p1", id);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static void DayResult(int day)
		{
			SqlCommand cmd = new SqlCommand("select ÇalışanID,İşletmeTürü from TBL_İşletme \n inner join TBL_Çalışan on TBL_Çalışan.ÇalıştığıIşletme=TBL_İşletme.İşletmeID", Context.context);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			List<int> ids = new List<int>();
			List<int> iids = new List<int>();

			while(rd.Read())
			{
				ids.Add(Convert.ToInt32(rd["ÇalışanID"]));
				iids.Add(Convert.ToInt32(rd["İşletmeTürü"]));
			}

			rd.Close();

			SqlCommand cmd2 = new SqlCommand("update TBL_User set UserParaMiktarı -= 20*@p4, UserEşyaMiktarı -= 20*@p4 where UserID=@p1", Context.context);
			SqlCommand cmd3 = new SqlCommand("update TBL_User set UserYemekMiktarı -= 20*@p4, UserParaMiktarı -= 20*@p4 where UserID=@p2", Context.context);
			SqlCommand cmd4 = new SqlCommand("update TBL_User set UserYemekMiktarı -= 20*@p4, UserEşyaMiktarı -= 20*@p4 where UserID=@p3", Context.context);
			SqlCommand cmd5 = new SqlCommand("update TBL_User set UserYemekMiktarı -= 20*@p4, UserEşyaMiktarı -= 20*@p4, UserParaMiktarı -= 20*@p4 where ÇalışmaDurumu=0", Context.context);
			SqlCommand cmd6 = new SqlCommand("update TBL_Çalışan set ÇalışanGünSayısı += @p4", Context.context);
			
			for(int i=0;i<ids.Count;i++)
			{
				switch(iids[i])
				{
					case 1:
						cmd2.Parameters.Add("@p4", day);
						cmd2.Parameters.Add("@p1", ids[i]);
						cmd2.ExecuteNonQuery();
						cmd2.Parameters.Clear();
						break;
					case 2:
						cmd3.Parameters.Add("@p4", day);
						cmd3.Parameters.AddWithValue("@p2", ids[i]);
						cmd3.ExecuteNonQuery();
						cmd3.Parameters.Clear();
						break;
					case 3:
						cmd4.Parameters.Add("@p4", day);
						cmd4.Parameters.AddWithValue("@p3", ids[i]);
						cmd4.ExecuteNonQuery();
						cmd4.Parameters.Clear();
						break;
				}
			}

			//Çalışmayan Tüm Oyuncuların Güncellemeleri
			cmd5.Parameters.Add("@p4", day);
			cmd5.ExecuteNonQuery();
			cmd5.Parameters.Clear();

			//Çalışan Oyuncuların Çalışma Gün Sayıları Güncellemesi
			cmd6.Parameters.Add("@p4", day);
			cmd6.ExecuteNonQuery();

		}
		public static bool BuyFood(int userid,int marketid,int miktar)
		{
			SqlCommand cmd = new SqlCommand("select YiyecekÜcreti from TBL_Market where MarketID=@p4", Context.context);
			cmd.Parameters.Add("@p4", marketid);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			int yiyecekücreti = 0;
			while(rd.Read())
			{
				yiyecekücreti = Convert.ToInt32(rd["YiyecekÜcreti"]);
			}
			rd.Close();

			SqlCommand cmd2 = new SqlCommand("update TBL_User set UserYemekMiktarı += @p1,UserParaMiktarı -= @p1*@p2 where UserID=@p3", Context.context);
			cmd2.Parameters.Add("@p1", miktar);
			cmd2.Parameters.Add("@p2", yiyecekücreti);
			cmd2.Parameters.Add("@p3", userid);

			if (cmd2.Connection.State != ConnectionState.Open)
			{
				cmd2.Connection.Open();
			}

			return cmd2.ExecuteNonQuery() > 0;
		}
		public static bool GetJob(int userid, int işletme,int günlüksaat)
		{
			SqlCommand cmd = new SqlCommand("insert into TBL_Çalışan (ÇalışanGünlükSaati,ÇalışanID,ÇalıştığıIşletme) values (@p1,@p2,@p3)", Context.context);
			SqlCommand cmd2 = new SqlCommand("update TBL_User set ÇalışmaDurumu=@p4 where UserID=@p2", Context.context);
			cmd.Parameters.Add("@p1", günlüksaat);
			cmd.Parameters.Add("@p2", userid);
			cmd.Parameters.Add("@p3", işletme);
			cmd2.Parameters.Add("@p2", userid);
			cmd2.Parameters.Add("@p4", 1);

			cmd2.ExecuteNonQuery();

			return cmd.ExecuteNonQuery() > 0;
		}
		public static int infoJob(int userid)
		{
			SqlCommand cmd = new SqlCommand("select ÇalışmaDurumu from TBL_User where UserID=@p1", Context.context);
			cmd.Parameters.Add("@p1", userid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd= cmd.ExecuteReader();

			bool durum = true;

			while(rd.Read())
			{
				durum = Convert.ToBoolean(rd["ÇalışmaDurumu"]);
			}

			rd.Close();

			if(!durum)
			{
				return 0;
			}

			SqlCommand cmd2 = new SqlCommand("select İşletmeTürü from TBL_Çalışan \n inner join TBL_İşletme on TBl_İşletme.İşletmeID=TBL_Çalışan.ÇalıştığıIşletme where ÇalışanID=@p2", Context.context);
			cmd2.Parameters.Add("@p2", userid);

			if (cmd2.Connection.State != ConnectionState.Open)
			{
				cmd2.Connection.Open();
			}

			cmd2.ExecuteNonQuery();

			SqlDataReader rd2 = cmd2.ExecuteReader();

			int isletme = 56;

			while(rd2.Read())
			{
				isletme = Convert.ToInt32(rd2["İşletmeTürü"]);
			}
			rd2.Close();

			return isletme;
		}
		public static bool resignationJob(int userid)
		{
			SqlCommand cmd = new SqlCommand("delete TBL_Çalışan where ÇalışanID=@p1", Context.context);
			cmd.Parameters.Add("@p1", userid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			bool result1 = cmd.ExecuteNonQuery() > 0;
			cmd.Parameters.Clear();

			SqlCommand cmd2 = new SqlCommand("update TBL_User set ÇalışmaDurumu=@p1 where UserID=@p2", Context.context);
			cmd2.Parameters.Add("@p1", Convert.ToInt32(0));
			cmd2.Parameters.Add("@p2", userid);

			bool result2 = cmd2.ExecuteNonQuery() > 0;
			cmd2.Parameters.Clear();

			return result1 & result2;
		}
		public static bool buyFurniture(int userid,int magazaid,int miktar)
		{
			SqlCommand cmd = new SqlCommand("select EşyaÜcreti from TBL_Mağaza where MagazaID=@p1", Context.context);
			cmd.Parameters.Add("@p1", magazaid);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			int esyaucreti = 56;
			while(rd.Read())
			{
				esyaucreti = Convert.ToInt32(rd["EşyaÜcreti"]);
			}
			rd.Close();

			SqlCommand cmd2 = new SqlCommand("update TBL_User set UserParaMiktarı -= @p1*@p4,UserEşyaMiktarı += @p4 where UserID=@p3", Context.context);
			cmd2.Parameters.Add("@p1", esyaucreti);
			cmd2.Parameters.Add("@p4", miktar);
			cmd2.Parameters.Add("@p3", userid);

			return cmd2.ExecuteNonQuery() > 0;
		}
		public static bool ResetUser()
		{
			SqlCommand cmd = new SqlCommand("update TBL_User set UserParaMiktarı=1000,UserEşyaMiktarı=1000,UserYemekMiktarı=1000", Context.context);
			
			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool downMoney(int money,int userid)
		{
			SqlCommand cmd = new SqlCommand("update TBL_User set UserParaMiktarı-=@p1 where UserID=@p2", Context.context);
			cmd.Parameters.Add("@p1", money);
			cmd.Parameters.Add("@p2", userid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
	}
}
