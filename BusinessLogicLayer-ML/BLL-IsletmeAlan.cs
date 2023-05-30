using System.Collections.Generic;
using EntityLayer_ML;
using DataAccessLayer_ML;
using System;
using System.Linq;

namespace BusinessLogicLayer_ML
{
	public class BLL_IsletmeAlan
	{
		public static List<int> areaColor()
		{
			List<İşletmeAlan> areas = DAL_IsletmeAlan.getAreaList();
			List<int> colors = new List<int>();

			foreach(İşletmeAlan i in areas)
			{
				if(i.getAlanTur())
				{
					colors.Add(i.getIsletmeTur());
				}
				else
				{
					colors.Add(0);
				}
				
			}

			return colors;
		}
		public static List<string> areaID()
		{
			List<string> areasID = new List<string>();

			foreach(İşletmeAlan i in DAL_IsletmeAlan.getAreaList())
			{
				if(i.getAlanID() < 10)
				{
					areasID.Add("0"+i.getAlanID().ToString());
				}
				else
				{
					areasID.Add(i.getAlanID().ToString());
				}
				
			}

			return areasID;
		}
		public static List<İşletmeAlan> getBusinessAreasList(int isletmeid)
		{
			List<İşletmeAlan> areas = DAL_IsletmeAlan.getBusinessAreas(isletmeid);
			foreach(İşletmeAlan i in areas)
			{
				if(i.getAlanID() < 10)
				{
					i.setAlanIDS("0");
				}
			}

			return areas;
		}
		public static List<İşletmeAlan> getBusinessAreasListbyUser(int userid)
		{
			List<İşletmeAlan> areas = DAL_IsletmeAlan.getBusinessAreasbyUser(userid);
			foreach (İşletmeAlan i in areas)
			{
				if (i.getAlanID() < 10)
				{
					i.setAlanIDS("0");
				}
			}

			return areas;
		}
		public static bool buyArea(int userid,string areaIDs)
		{
			int p1, p2;
			char[] areas1 = areaIDs.ToCharArray();

			if(areas1.Length == 4)
			{
				if (areas1[0] != '0')
				{
					int k = int.Parse(areas1[0].ToString());
					int l = int.Parse(areas1[1].ToString());

					p1 = k * 10 + l;
				}
				else
				{
					p1 = int.Parse(areas1[1].ToString());
				}

				if (areas1[2] != '0')
				{
					int m = int.Parse(areas1[2].ToString());
					int n = int.Parse(areas1[3].ToString());

					p2 = m * 10 + n;
				}
				else
				{
					p2 = int.Parse(areas1[3].ToString());
				}

				return DAL_IsletmeAlan.buyArea1(userid, p1, p2);
			}

			else
			{
				if (areas1[0] != '0')
				{
					int k = int.Parse(areas1[0].ToString());
					int l = int.Parse(areas1[1].ToString());

					p1 = k * 10 + l;
				}
				else
				{
					p1 = int.Parse(areaIDs[1].ToString());
				}

				return DAL_IsletmeAlan.buyArea2(userid, p1);
			}

			

			

		}
		public static bool convertArea(string areaID,int userid,int isletmetur)
		{
			int p1;
			char[] areas = areaID.ToCharArray();

			if (areas[0] != '0')
			{
				p1 = int.Parse((areas[0] + areas[1]).ToString());
			}
			else
			{
				p1 = int.Parse(areas[1].ToString());
			}

			return DAL_IsletmeAlan.convertArea(p1, userid, isletmetur);
		}
	}
}
