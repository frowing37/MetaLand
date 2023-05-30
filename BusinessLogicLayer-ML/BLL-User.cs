using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using BusinessLogicLayer_ML;
using DataAccessLayer_ML;
using EntityLayer_ML;

namespace BusinessLogicLayer_ML
{
	public class BLL_User
	{
		public static User Login(string username,string password)
		{
			List<User> Users = DAL_User.GetList();

			foreach(User e in Users)
			{
				if(e.isLog(username,password))
				{
					return e;
				}
			}

			return null;
		}
		public static int SignUp(string username,string password)
		{
			if(username == null || password == null)
			{
				return 0;
			}

			string[] adsoyad = username.Split(' ');
			
			User newuser = new User(adsoyad[0], adsoyad[1], password);
			
			if(DAL_User.Create(newuser))
			{
				return 1;
			}

			else
			{
				return -1;
			}
		} 
		public static User GetUser(int id)
		{
			List<User> Users = DAL_User.GetList();
			foreach (User u in Users)
			{
			  if(u.ID == id)
				{

					return u;
				}
			}

			return null;
		}
		public static bool UpdateColumnsDefault(string columnName, string defaultValue)
		{
			if(DAL_User.UpdateDefault(columnName, defaultValue))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static DataTable GetUserList()
		{
			List<User> Users = DAL_User.GetList();
			DataTable dt = new DataTable();
			dt.Columns.Add("ID", typeof(int));
			dt.Columns.Add("Ad", typeof(string));
			dt.Columns.Add("Soyad", typeof(string));
			dt.Columns.Add("Şifre", typeof(string));
			dt.Columns.Add("Yemek", typeof(int));
			dt.Columns.Add("Eşya", typeof(int));
			dt.Columns.Add("Para", typeof(int));
			dt.Columns.Add("Tarih", typeof(DateTime));
			
			foreach(User u in Users)
			{
				dt.Rows.Add(u.ID,u.displayAd, u.displaySoyad, u.getSifre(), u.displayPuanlar[0], u.displayPuanlar[1], u.displayPuanlar[2], u.displayTarih);
			}

			return dt;
		}
		public static bool UpdateUser(int ID,string Ad, string Soyad, string Şifre, int Yemek, int Para, int Eşya, DateTime Tarih, bool Admin)
		{
			if(DAL_User.UpdateUser(ID,Ad, Soyad, Şifre, Yemek, Para, Eşya, Tarih, Admin))
			{
				return true;
			}

			else
			{
				return false;
			}
		}
		public static bool DeleteUser(int ID)
		{
			if(DAL_User.DeleteUser(ID))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static void DayResults(int day)
		{
			DAL_User.DayResult(day);
		}
		public static bool BuyFood(int userid,int marketid,int miktar)
		{
			if(DAL_User.BuyFood(userid,marketid,miktar))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool GetJob(int userid, int işletme, int günlüksaat)
		{
			if(DAL_User.GetJob(userid,işletme,günlüksaat))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static int infoJob(int userid)
		{
			return DAL_User.infoJob(userid);
		}
		public static bool resignationJob(int userid)
		{
			if(DAL_User.resignationJob(userid))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool buyFurniture(int userid,int magazaid,int miktar)
		{
			if(DAL_User.buyFurniture(userid,magazaid,miktar))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool resetUsers()
		{
			if(DAL_User.ResetUser())
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public static bool downMoney(int money,int userid)
		{
			return DAL_User.downMoney(money,userid);
		}

	}
}
