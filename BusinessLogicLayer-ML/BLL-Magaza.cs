using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer_ML;
using DataAccessLayer_ML;
using System.Data;
using System.CodeDom;

namespace BusinessLogicLayer_ML
{
	public class BLL_Magaza
	{
		public static DataTable getMagazaTable()
		{
			List<Mağaza> magazas = DAL_Magaza.getMagazaList();
			DataTable dt = new DataTable();
			dt.Columns.Add("MağazaID", typeof(int));
			dt.Columns.Add("Eşya Ücreti", typeof(int));
			dt.Columns.Add("Mağaza Sahibi", typeof(string));
			dt.Columns.Add("Kapasite", typeof(int));
			dt.Columns.Add("Çalışan Sayısı", typeof(int));

			foreach(Mağaza m in magazas)
			{
				dt.Rows.Add(m.getMagazaID(),m.getEsyaUcreti(),m.getMagazaSahibi(),m.getMagazaKapasitesi(),m.getMagazaCalisanSayisi());
			}

			return dt;
		}
		public static Mağaza getMagazaAttributes(int magazaid)
		{
			return DAL_Magaza.getMagazaAttributes(magazaid);
		}
	}
}
