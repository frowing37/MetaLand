using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using EntityLayer_ML;
using DataAccessLayer_ML;

namespace BusinessLogicLayer_ML
{
	public class BLL_Market
	{
		public static DataTable getTableMarket()
		{
			List<Market> markets = DAL_Market.getListMarket();
			DataTable dt = new DataTable();
			dt.Columns.Add("Market ID", typeof(int));
			dt.Columns.Add("Yiyecek Ücreti", typeof(int));
			dt.Columns.Add("İşletme Yöneticisi", typeof(string));
			dt.Columns.Add("Kapasite", typeof(int));
			dt.Columns.Add("Çalışan Sayısı", typeof(int));

			foreach(Market m in markets)
			{
				dt.Rows.Add(m.getIsletmeID(),m.getYiyececkUcreti(),m.getMarketYonetici(),m.getMarketKapasite(),m.getMarketCalisanSayi());
			}

			return dt;
		}
		public static Market getMarketAttributies(int marketid)
		{
			return DAL_Market.getMarketAttributies(marketid);
		}
	}
}
