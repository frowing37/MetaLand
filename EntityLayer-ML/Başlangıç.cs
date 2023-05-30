using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer_ML
{
	public class Başlangıç
	{
		private int BaslangicPara;
		private int BaslangicEsya;
		private int BaslangicYemek;
		private int BaslangicX;
		private int BaslangicY;
		private int BaslangicGun;

		public Başlangıç(int baslangicPara, int baslangicEsya, int baslangicYemek, int x, int y, int baslangicGun)
		{
			BaslangicPara = baslangicPara;
			BaslangicEsya = baslangicEsya;
			BaslangicYemek = baslangicYemek;
			BaslangicX = x;
			BaslangicY = y;
			BaslangicGun = baslangicGun;
		}

		public int getBaslangicGun()
		{
			return BaslangicGun;
		}
		public int getBaslangicPara()
		{
			return BaslangicPara;
		}

		public int getBaslangicEsya()
		{
			return BaslangicEsya;
		}
		public int getBaslangicYemek()
		{
			return BaslangicYemek;
		}

		public int getBaslangicX()
		{
			return BaslangicX;
		}

		public int getBaslangicY()
		{
			return BaslangicY;
		}

	}
}
