using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_ML
{
	public class Emlak
	{
		private int EmlakID;
		private int EmlakKomisyon;
		private int EmlakAlis;
		private int EmlakSatis;
		private int KiraSuresi;
		private int KiraFiyat;
		private DateTime SatisTarihi;
		private DateTime KiralamaTarihi;
		private DateTime KiraBitisTarihi;
		private string EmlakSahibi;
		private int EmlakMaas;
		private int GunlukSaat;

		public Emlak(int emlakID, int emlakKomisyon, int emlakAlis, int emlakSatis, int kiraSuresi, DateTime satisTarihi, DateTime kiralamaTarihi, DateTime kiraBitisTarihi)
		{
			EmlakID = emlakID;
			EmlakKomisyon = emlakKomisyon;
			EmlakAlis = emlakAlis;
			EmlakSatis = emlakSatis;
			KiraSuresi = kiraSuresi;
			SatisTarihi = satisTarihi;
			KiralamaTarihi = kiralamaTarihi;
			KiraBitisTarihi = kiraBitisTarihi;
		}

		public Emlak(int emlakID, int emlakSatis, int emlakAlis, DateTime kiraBitisTarihi, string emlakSahibi, int kiraFiyat)
		{
			this.EmlakID = emlakID;
			this.EmlakSatis = emlakSatis;
			this.EmlakAlis = emlakAlis;
			this.KiraBitisTarihi = kiraBitisTarihi;
			this.EmlakSahibi = emlakSahibi;
			KiraFiyat = kiraFiyat;
		}

		public Emlak(int maas,int saat)
		{
			this.EmlakMaas = maas;
			this.GunlukSaat = saat;
		}
		public int getGunlukSaat()
		{
			return this.GunlukSaat;
		}
		public int getMaas()
		{
			return this.EmlakMaas;
		}
		public int getKirafİyat()
		{
			return this.KiraFiyat;
		}
		public string getEmlakSahibi()
		{
			return this.EmlakSahibi;
		}
		public DateTime getKiraBitisTarih()
		{
			return this.KiraBitisTarihi;
		}
		public int getEmlakAlis()
		{
			return this.EmlakAlis;
		}
		public int getEmlakSatis()
		{
			return this.EmlakSatis;
		}
		public int getEmlakID()
		{
			return this.EmlakID;
		}

	}
}
