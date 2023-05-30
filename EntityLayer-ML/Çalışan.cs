using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_ML
{
	public class Çalışan
	{
		private int CalısanID;
		private int CalistigiIsletme;
		private DateTime CalısanBaslangicTarih;
		private DateTime BitisTarih;
		private int CalisanGunSayisi;
		private int CalisanGunlukSaati;
		private int CalisanMaas;

		public Çalışan(int calısanID,int calistigiIsletme, DateTime calısanBaslangicTarih, DateTime bitisTarih, int calisanGunSayisi, int calisanGunlukSaati)
		{
			this.CalısanID = calısanID;
			this.CalistigiIsletme = calistigiIsletme;
			this.CalısanBaslangicTarih = calısanBaslangicTarih;
			this.BitisTarih = bitisTarih;
			this.CalisanGunSayisi = calisanGunSayisi;
			this.CalisanGunlukSaati = calisanGunlukSaati;
		}
		public Çalışan(int calisanID,int calisanMaas)
		{
			this.CalısanID = calisanID;
			this.CalisanMaas = calisanMaas;
		}

		public int getCalisanMaas()
		{
			return this.CalisanMaas;
		}
		public int getCalısanID()
		{
			return this.CalısanID;
		}
		public int getCalistigiIsletme()
		{
			return this.CalistigiIsletme;
		}
		public int getCalisanGunSayisi()
		{
			return this.CalisanGunSayisi;
		}
		public int getCalisanGunlukSaati()
		{
			return this.CalisanGunlukSaati;
		}

		public DateTime getCalısanBaslangicTarih()
		{
			return this.CalısanBaslangicTarih;
		}
		public DateTime getBitisTarih()
		{
			return this.BitisTarih;
		}
	}
}
