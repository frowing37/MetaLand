using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_ML
{
	public class İşletmeAlan
	{
		private int AlanID;
		private bool AlanTürü;
		private int AlanSahibi;
		private int İşletmeID;
		private int IsletmeTur;
		private string AlanIDS;
		public İşletmeAlan(int alanID, bool alanTürü, int alanSahibi, int işletmeID, int ısletmeTur)
		{
			AlanID = alanID;
			AlanTürü = alanTürü;
			AlanSahibi = alanSahibi;
			İşletmeID = işletmeID;
			IsletmeTur = ısletmeTur;
		}

		public İşletmeAlan(string alanIDS,int alanID, bool alanTürü, int alanSahibi, int işletmeID)
		{
			this.AlanIDS = alanIDS;
			this.AlanID = alanID;
			this.AlanTürü = alanTürü;
			this.AlanSahibi = alanSahibi;
			this.İşletmeID = işletmeID;
		}
		public İşletmeAlan(int alanID)
		{
			this.AlanID = alanID;
		}
		public void setAlanIDS(string a)
		{
			AlanIDS = a + AlanIDS;
		}
		public string getAlanIDS()
		{
			return this.AlanIDS;
		}
		public int getIsletmeTur()
		{
			return this.IsletmeTur;
		}
		public int getAlanID()
		{
			return this.AlanID;
		}

		public bool getAlanTur()
		{
			return this.AlanTürü;
		}
		public int getAlanSahibi()
		{
			return this.AlanSahibi;
		}
	}
}
