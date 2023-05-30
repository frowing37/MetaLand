using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_ML
{
	public class İşletme
	{
		private int IsletmeID;
		private int IsletmeTuru;
		private int IsletmeYoneticiUcreti;
		private int IsletmeKullaniciUcreti;
		private int IsletmeSeviyesi;
		private int IsletmeKapasite;
		private int IsletmeCalisanSayisi;
		private int IsletmeKiraFiyat;
		private int IsletmeSabitGelirMiktari;
		private int IsletmeSabitGelirOrani;
		private int IsletmeYoneticiID;
		private int IsletmeTurFiyat;
		

		public İşletme(int ısletmeID, int ısletmeTuru, int ısletmeYoneticiUcreti, int ısletmeKullaniciUcreti, int ısletmeSeviyesi, int ısletmeKapasite, int ısletmeCalisanSayisi, int ısletmeKiraFiyat, int ısletmeSabitGelirMiktari, int ısletmeSabitGelirOrani, int ısletmeYoneticiID)
		{
			IsletmeID = ısletmeID;
			IsletmeTuru = ısletmeTuru;
			IsletmeYoneticiUcreti = ısletmeYoneticiUcreti;
			IsletmeKullaniciUcreti = ısletmeKullaniciUcreti;
			IsletmeSeviyesi = ısletmeSeviyesi;
			IsletmeKapasite = ısletmeKapasite;
			IsletmeCalisanSayisi = ısletmeCalisanSayisi;
			IsletmeKiraFiyat = ısletmeKiraFiyat;
			IsletmeSabitGelirMiktari = ısletmeSabitGelirMiktari;
			IsletmeSabitGelirOrani = ısletmeSabitGelirOrani;
			IsletmeYoneticiID = ısletmeYoneticiID;
		}

		public İşletme(int id)
		{
			this.IsletmeID = id;
		}
		
		public İşletme(int id,int isletmeturfiyat)
		{
			this.IsletmeID = id;
			this.IsletmeTurFiyat = isletmeturfiyat;
		}

		public int getID()
		{
			return this.IsletmeID;
		}

		public int getTur()
		{
			return this.IsletmeTuru;
		}

		public int getYoneticiUcreti()
		{
			return this.IsletmeYoneticiUcreti;
		}

		public int getKullaniciUcreti()
		{
			return this.IsletmeKullaniciUcreti;
		}
		public int getSeviye()
		{
			return this.IsletmeSeviyesi;
		}
		public int getKapasite()
		{
			return this.IsletmeKapasite;
		}
		public int getCalisanSayisi()
		{
			return this.IsletmeCalisanSayisi;
		}
		public int getKiraFiyat()
		{
			return this.IsletmeKiraFiyat;
		}
		public int getSabitGelirMiktar()
		{
			return this.IsletmeSabitGelirMiktari;
		}
		public int getSabitGelirOran()
		{
			return this.IsletmeSabitGelirOrani;
		}
		public int getYoneticiID()
		{
			return this.IsletmeYoneticiID;
		}
	}
}
