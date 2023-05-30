using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_ML
{
	public class Market
	{
		private int IsletmeID;
		private int YiyecekUcreti;
		private int YoneticiID;
		private int MarketKapasite;
		private int MarketCalisanSayi;
		private int MarketMaas;
		private int MarketCalismaSaati;
		private string MarketYonetici;
		public Market(int isletmeID,int yiyecekUcreti, string marketYonetici, int marketKapasite, int marketCalisanSayi)
		{
			this.IsletmeID = isletmeID;
			this.YiyecekUcreti = yiyecekUcreti;
			this.MarketYonetici = marketYonetici;
			this.MarketKapasite = marketKapasite;
			this.MarketCalisanSayi = marketCalisanSayi;
		}

		public Market(int marketmaas,int calismasaati)
		{
			this.MarketMaas = marketmaas;
			this.MarketCalismaSaati = calismasaati;
		}
		public string getMarketYonetici()
		{
			return this.MarketYonetici;
		}
		public int getMarketCalismaSaati()
		{
			return this.MarketCalismaSaati;
		}
		public int getMarketMaas()
		{
			return this.MarketMaas;
		}
		public int getMarketCalisanSayi()
		{
			return this.MarketCalisanSayi;
		}
		public int getMarketKapasite()
		{
			return this.MarketKapasite;
		}
		public int getYoneticiID()
		{
			return this.YoneticiID;
		}

		public int getIsletmeID()
		{
			return this.IsletmeID;
		}

		public int getYiyececkUcreti()
		{
			return this.YiyecekUcreti;
		}


	}
}
