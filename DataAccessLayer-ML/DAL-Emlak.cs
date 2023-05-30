using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using EntityLayer_ML;
using System.Data;

namespace DataAccessLayer_ML
{
	public class DAL_Emlak
	{
		public static List<Emlak> getEmlakList()
		{
			List<Emlak> emlaks = new List<Emlak>();

			SqlCommand cmd = new SqlCommand("select *,İşletmeYöneticiID from TBL_Emlak \n inner join TBL_İşletme on TBL_İşletme.İşletmeID=TBL_Emlak.EmlakID", Context.context);

			if(cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				emlaks.Add(new Emlak(Convert.ToInt32(rd["EmlakID"]), Convert.ToInt32(rd["EmlakSatış"]), Convert.ToInt32(rd["EmlakAlış"]), Convert.ToDateTime(rd["KiraBitişTarihi"]), rd["İşletmeYöneticiID"].ToString(), Convert.ToInt32(rd["KiraFiyat"])));
			}

			rd.Close();

			return emlaks;
		}
		public static Emlak getEmlakAttributes(int emlakid)
		{
			SqlCommand cmd = new SqlCommand("select İşletmeKullanıcıÜcreti,İşletmeGünlükÇalışanSaat from TBL_İşletme where İşletmeID=@p1", Context.context);
			cmd.Parameters.Add("@p1", emlakid);

			if (cmd.Connection.State != ConnectionState.Open)
			{
				cmd.Connection.Open();
			}

			Emlak e = null;
			SqlDataReader rd = cmd.ExecuteReader();

			while(rd.Read())
			{
				e = new Emlak(Convert.ToInt32(rd["İşletmeKullanıcıÜcreti"]), Convert.ToInt32(rd["İşletmeGünlükÇalışanSaat"]));
			}
			rd.Close();

			return e;
		}
	}
}
