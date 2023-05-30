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
	public class BLL_Isletmeler
	{
		public static DataTable GetTableIsletme()
		{
			List<İşletme> isletmes = DAL_Isletmeler.GetIsletmeList();

			DataTable dt = new DataTable();
			dt.Columns.Add("ID", typeof(int));
			dt.Columns.Add("İşletme Türü", typeof(int));
			dt.Columns.Add("Yönetici ID", typeof(int));
			dt.Columns.Add("Yönetici Ücreti", typeof(int));
			dt.Columns.Add("Kullanıcı Ücreti", typeof(int));
			dt.Columns.Add("Seviye", typeof(int));
			dt.Columns.Add("Kapasite", typeof(int));
			dt.Columns.Add("Çalışan Sayısı", typeof(int));
			dt.Columns.Add("Kira Fiyatı", typeof(int));
			dt.Columns.Add("Sabit Gelir Miktarı", typeof(int));
			dt.Columns.Add("Sabit Gelir Oranı", typeof(int));

			foreach(İşletme i in isletmes)
			{
				dt.Rows.Add(i.getID(),i.getTur(),i.getYoneticiID(),i.getYoneticiUcreti(),i.getKullaniciUcreti(),i.getSeviye(),i.getKapasite(),i.getCalisanSayisi(),i.getKiraFiyat(),i.getSabitGelirMiktar(),i.getSabitGelirOran());
			}

			return dt;
		}
		public static bool UpdateIsletme(int id,int tur, int yoneticiucreti, int kullaniciucreti, int seviye, int kapasite, int calisansayisi, int kira, int sbtmiktar, int sbtoran, int yoneticiid)
		{
			if(DAL_Isletmeler.UpdateIsletme(id,tur,yoneticiucreti,kullaniciucreti,seviye,kapasite,calisansayisi,kira,sbtmiktar,sbtoran,yoneticiid))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool DeleteIsletme(int id)
		{
			if(DAL_Isletmeler.DeleteIsletme(id))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool amIBoss(int userid)
		{
			return DAL_Isletmeler.amIBoss(userid);
		}
	}
}
