using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using EntityLayer_ML;

namespace DataAccessLayer_ML
{
	public class DAL_Magaza
	{
		public static List<Mağaza> getMagazaList()
		{
			List<Mağaza> magazas = new List<Mağaza>();
			SqlCommand cmd = new SqlCommand("select MagazaID,EşyaÜcreti,UserName,UserSoyad,İşletmeKapasitesi,İşletmeÇalışanSayısı from TBL_İşletme \n inner join TBl_Mağaza on TBL_Mağaza.MagazaID=TBL_İşletme.İşletmeID \n inner join TBL_User on TBL_User.UserID=TBL_İşletme.İşletmeYöneticiID", Context.context);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				magazas.Add(new Mağaza(Convert.ToInt32(rd["EşyaÜcreti"]), Convert.ToInt32(rd["MagazaID"]), rd["UserName"].ToString() + " " + rd["UserSoyad"].ToString(), Convert.ToInt32(rd["İşletmeÇalışanSayısı"]), Convert.ToInt32(rd["İşletmeKapasitesi"])));
			}
			rd.Close();

			return magazas;
		}
		public static Mağaza getMagazaAttributes(int magazaid)
		{
			Mağaza m = null;
			SqlCommand cmd = new SqlCommand("select İşletmeKullanıcıÜcreti,İşletmeGünlükÇalışanSaat from TBL_İşletme where İşletmeID = @p1", Context.context);
			cmd.Parameters.Add("@p1", magazaid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				m = new Mağaza(Convert.ToInt32(rd["İşletmeGünlükÇalışanSaat"]), Convert.ToInt32(rd["İşletmeKullanıcıÜcreti"]));
			}
			rd.Close();

			return m; 
		}
	}
}
