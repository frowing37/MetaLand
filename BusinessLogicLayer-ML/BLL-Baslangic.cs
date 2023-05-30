using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer_ML;
using DataAccessLayer_ML;
using System.Xml.Schema;

namespace BusinessLogicLayer_ML
{
	public class BLL_Baslangic
	{
		public static Başlangıç GetBaslangic()
		{
			return DAL_Baslangic.readBaslangic()[0];
		}

		public static bool UpdateXY(int x,int y)
		{
			if(DAL_Baslangic.UpdateXY(x,y))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool IncreaseDay(int day)
		{
			if(DAL_Baslangic.IncreaseDay(day))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool resetDay()
		{
			if(DAL_Baslangic.resetDay())
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
