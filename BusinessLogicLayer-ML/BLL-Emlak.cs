using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer_ML;
using DataAccessLayer_ML;
using System.Data;
using System.Data.SqlClient;

namespace BusinessLogicLayer_ML
{
	public class BLL_Emlak
	{
		public static DataTable getEmlakTable()
		{
			List<Emlak> emlaks = DAL_Emlak.getEmlakList();

			DataTable dt = new DataTable();
			dt.Columns.Add("Emlak ID",typeof(int));
			dt.Columns.Add("Arsa Satış Fiyatı", typeof(int));
			dt.Columns.Add("Emlak Sahibi", typeof(string));
			dt.Columns.Add("Kira Fiyat", typeof(int));

			foreach(Emlak e in emlaks)
			{
				dt.Rows.Add(e.getEmlakID(), e.getEmlakSatis(), e.getEmlakSahibi(), e.getKirafİyat());
			}

			return dt;
		}
		public static Emlak getEmlakAttributes(int emlakid)
		{
			return DAL_Emlak.getEmlakAttributes(emlakid);
		}
		public static int getEmlakPrice(int emlakid)
		{
			List<Emlak> emlaks = DAL_Emlak.getEmlakList();
			int price = 0;
			foreach(Emlak e in emlaks)
			{
				if(e.getEmlakID() == emlakid)
				{
					price = e.getEmlakSatis();
					break;
				}
			}

			return price;
		}
	}
}
