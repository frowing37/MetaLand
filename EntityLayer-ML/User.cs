using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_ML
{
	public class User
	{
		public int ID;
		private string Ad;
		private string Soyad;
		private string Şifre;
		private int YemekMiktarı;
		private int EşyaMiktarı;
		private int ParaMiktarı;
		private DateTime OyunBaşlangıçTarihi;
		private bool Admin;
		private bool CalismaDurumu;

		public string displayAd;
		public string displaySoyad;
		public string displayŞifre;
		public int[] displayPuanlar = new int[3];
		public DateTime displayTarih;

		public User()
		{

		}
		public User(int iD, string ad, string soyad, string şifre, int yemekMiktarı, int eşyaMiktarı, int paraMiktarı, DateTime oyunBaşlangıçTarihi,bool admin, bool calismaDurumu)
		{
			this.ID = iD;
			this.Ad = ad;
			this.Soyad = soyad;
			this.Şifre = şifre;
			this.YemekMiktarı = yemekMiktarı;
			this.EşyaMiktarı = eşyaMiktarı;
			this.ParaMiktarı = paraMiktarı;
			this.OyunBaşlangıçTarihi = oyunBaşlangıçTarihi;
			this.displayAd = ad;
			this.displaySoyad = soyad;
			this.displayPuanlar[0] = yemekMiktarı;
			this.displayPuanlar[1] = eşyaMiktarı;
			this.displayPuanlar[2] = paraMiktarı;
			this.displayTarih = oyunBaşlangıçTarihi;
			this.Admin = admin;
			this.CalismaDurumu = calismaDurumu;
		}

		public User(string ad, string soyad, string şifre)
		{
			Ad = ad;
			Soyad = soyad;
			Şifre = şifre;
			displayAd = ad;
			displaySoyad = soyad;
			displayŞifre = şifre;
		}

		public int getParaMiktarı()
		{
			return this.ParaMiktarı;
		}
		public int getEsyaMiktarı()
		{
			return this.EşyaMiktarı;
		}
		public int getYemekMiktarı()
		{
			return this.YemekMiktarı; 
		}
		public bool isLog(string a,string b)
		{
			if(this.Ad + " " + this.Soyad == a && this.Şifre == b)
			{
				return true;
			}

			else
			{
				return false;
			}
		}
		public bool isAdmin()
		{
			if(this.Admin)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public string getSifre()
		{
			return this.Şifre;
		}
		public bool getCalismaDurumu()
		{
			return this.CalismaDurumu;
		}
	}
}
