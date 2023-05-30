using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer_ML;
using DataAccessLayer_ML;
using System.Data;

namespace BusinessLogicLayer_ML
{
	public class BLL_Calisan
	{
		public static DataTable GetCalisanList()
		{
			List<Çalışan> calisans = DAL_Calisan.GetCalisanList();
			DataTable dt = new DataTable();
			dt.Columns.Add("ID",typeof(int));
			dt.Columns.Add("Çalıştığı İşletme",typeof(int));
			dt.Columns.Add("Çalıştığı Gün Sayısı", typeof(int));
			dt.Columns.Add("Çalıştığı Günlük Saat",typeof (int));
			dt.Columns.Add("Başladığı Tarih", typeof(DateTime));
			dt.Columns.Add("Bittiği Tarih", typeof(DateTime));

			foreach(Çalışan c in calisans)
			{
				dt.Rows.Add(c.getCalısanID(), c.getCalistigiIsletme(), c.getCalisanGunSayisi(), c.getCalisanGunlukSaati(), c.getCalısanBaslangicTarih(), c.getBitisTarih());
			}

			return dt;
		}
		public static bool UpdateCalisan(int isletme, DateTime bastarih, DateTime bitistarih, int gunsayisi, int gunluksaat, int calisanid)
		{
			if(DAL_Calisan.UpdateCalisan(isletme,bastarih,bitistarih,gunsayisi,gunluksaat,calisanid))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool DeleteCalisan(int id)
		{
			if(DAL_Calisan.DeleteCalisan(id))
			{
				return true;
			}
			else
			{ 
				return false; 
			}
		}
		public static void payIt(int day)
		{
			DAL_Calisan.payIt(day);
		}
	}
}
