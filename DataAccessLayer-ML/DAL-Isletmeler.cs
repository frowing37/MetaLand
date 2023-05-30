using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer_ML;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;

namespace DataAccessLayer_ML
{
	public class DAL_Isletmeler
	{
		public static List<İşletme> GetIsletmeList()
		{
			List<İşletme> isletmes = new List<İşletme>();
			SqlCommand cmd = new SqlCommand("select * from TBL_İşletme", Context.context);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while (rd.Read())
			{
				isletmes.Add(new İşletme(Convert.ToInt32(rd["İşletmeID"]), Convert.ToInt32(rd["İşletmeTürü"]), Convert.ToInt32(rd["İşletmeYöneticiÜcreti"]), Convert.ToInt32(rd["İşletmeKullanıcıÜcreti"]), Convert.ToInt32(rd["İşletmeSeviyesi"]), Convert.ToInt32(rd["İşletmeKapasitesi"]), Convert.ToInt32(rd["İşletmeÇalışanSayısı"]), Convert.ToInt32(rd["İşletmeKiraFiyat"]), Convert.ToInt32(rd["İşletmeSabitGelirMiktar"]), Convert.ToInt32(rd["İşletmeSabitGelirOran"]), Convert.ToInt32(rd["İşletmeYöneticiID"])));
			}

			rd.Close();

			return isletmes;
		}
		public static bool UpdateIsletme(int id,int tur,int yoneticiucreti,int kullaniciucreti,int seviye,int kapasite,int calisansayisi,int kira,int sbtmiktar,int sbtoran,int yoneticiid)
		{
			SqlCommand cmd = new SqlCommand("update TBL_İşletme set İşletmeTürü=@p1,İşletmeYöneticiÜcreti=@p2,İşletmeKullanıcıÜcreti=@p3,İşletmeSeviyesi=@p4,İşletmeKapasitesi=@p5,İşletmeÇalışanSayısı=@p6,İşletmeKiraFiyat=@p7,İşletmeSabitGelirMiktar=@p8,İşletmeSabitGelirOran=@p9,İşletmeYöneticiID=@p10", Context.context);
			cmd.Parameters.Add("@p1", tur);
			cmd.Parameters.Add("@p1", yoneticiucreti);
			cmd.Parameters.Add("@p1", kullaniciucreti);
			cmd.Parameters.Add("@p1", seviye);
			cmd.Parameters.Add("@p1", kapasite);
			cmd.Parameters.Add("@p1", calisansayisi);
			cmd.Parameters.Add("@p1", kira);
			cmd.Parameters.Add("@p1", sbtmiktar);
			cmd.Parameters.Add("@p1", sbtoran);
			cmd.Parameters.Add("@p1", yoneticiid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool DeleteIsletme(int id)
		{
			SqlCommand cmd = new SqlCommand("delete TBL_İşletme where İşletmeID=@p1", Context.context);
			cmd.Parameters.Add("@p1", id);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			return cmd.ExecuteNonQuery() > 0;
		}
		public static bool amIBoss(int userid)
		{
			SqlCommand cmd = new SqlCommand("select * from TBL_İşletme where İşletmeYöneticiID=@p1", Context.context);
			cmd.Parameters.Add("@p1", userid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();



			if(rd == null)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
	}
}
