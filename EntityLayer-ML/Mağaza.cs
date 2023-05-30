using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_ML
{
	public class Mağaza
	{
		private int EsyaUcreti;
		private int MagazaID;
		private string MagazaSahibi;
		private int MagazaCalisanSayisi;
		private int MagazaKapasitesi;
		private int MagazaCalismaSaati;
		private int MagazaMaas;

		public Mağaza()
		{

		}
		public Mağaza(int esyaUcreti)
		{
			EsyaUcreti = esyaUcreti;
		}
		public Mağaza(int magazacalismasaati,int magazamaas)
		{
			this.MagazaCalismaSaati = magazacalismasaati;
			this.MagazaMaas = magazamaas;
		}
		public Mağaza(int esyaUcreti, int magazaID, string magazaSahibi, int magazaCalisanSayisi, int magazaKapasitesi)
		{
			this.MagazaID = magazaID;
			this.EsyaUcreti= esyaUcreti;
			this.MagazaSahibi = magazaSahibi;
			this.MagazaCalisanSayisi = magazaCalisanSayisi;
			this.MagazaKapasitesi = magazaKapasitesi;
		}
		public int getMagazaCalismaSaati()
		{
			return this.MagazaCalismaSaati;
		}
		public int getMagazaMaas()
		{
			return this.MagazaMaas;
		}
		public int getEsyaUcreti()
		{
			return this.EsyaUcreti;
		}

		public int getMagazaKapasitesi()
		{
			return this.MagazaKapasitesi;
		}
		public int getMagazaCalisanSayisi()
		{
			return this.MagazaCalisanSayisi;
		}
		public string getMagazaSahibi()
		{
			return this.MagazaSahibi;
		}
		public int getMagazaID()
		{
			return this.MagazaID;
		}

	}
}
