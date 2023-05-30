using EntityLayer_ML;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer_ML;
using BusinessLogicLayer_ML;
using System.Windows.Forms.Design;

namespace MetaLand0._2
{
	public partial class Form2 : Form
	{
		int userid;
		int alansecme = 0;
		bool ok = false;
		bool ok2 = true;
		bool design = false;
		User u;
		public static List<Control> arazi = new List<Control>();
		
		public Form2(int id)
		{
			InitializeComponent();
			userid = id;
			panel2.Visible = false;
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			u = BLL_User.GetUser(userid);
			label5.Text = u.ID.ToString();
			label6.Text = u.displayPuanlar[0].ToString();
			label7.Text = u.displayPuanlar[1].ToString();
			label8.Text = u.displayPuanlar[2].ToString();
			label10.Text = u.displayAd + " " +u.displaySoyad;
			label13.Text = BLL_Baslangic.GetBaslangic().getBaslangicGun().ToString();
			switch(BLL_User.infoJob(userid))
			{
				case 0:
					label23.Text = "Çalışmıyor";
					istifa.Visible = false;
					break;
				case 1:
					label23.Text = "Market";
					istifa.Visible = true;
					break;
				case 2:
					label23.Text = "Mağaza";
					istifa.Visible = true;
					break;
				case 3:
					label23.Text = "Emlak";
					istifa.Visible = true;
					break;
			}

			foreach (Control c in panel2.Controls)
			{
				if (c.Name.Contains("area") && c is Button)
				{
					arazi.Add(c);
				}
			}

		}

		private void panel2_Paint(object sender, PaintEventArgs e)
		{
			if(ok)
			{
				Graphics g = panel2.CreateGraphics();
				Pen pen = new Pen(Color.DarkGray);

				Point startPoint = new Point(5, 5);

				Başlangıç b = BLL_Baslangic.GetBaslangic();

				int gridX = b.getBaslangicX();
				int gridY = b.getBaslangicY();
				int squareSize = 37;
				
				panel2.Height = (squareSize * gridY) + 10;
				panel2.Width = (squareSize * gridX) + 10;
				/*
				for (int i = 0; i < gridX; i++)
				{
					for (int j = 0; j < gridY; j++)
					{
						Rectangle square = new Rectangle(startPoint.X + i * squareSize, startPoint.Y + j * squareSize, squareSize, squareSize);
						g.DrawRectangle(pen, square);
					}
				}
				*/
				
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if(ok)
			{
				ok = false;
				panel2.Visible = false;
			}
			else
			{
				ok = true;
				panel2.Visible = true;
				foreach(Control c in panel2.Controls)
				{
					if(design)
					{
						c.Enabled = true;
					}
					else
					{
						c.Enabled = false;
					}
				}
				
				for(int i = 0; i < 100; i++)
				{
					foreach(Control c in arazi)
					{
						if (c.Name.Contains(BLL_IsletmeAlan.areaID()[i]))
						{
							switch (BLL_IsletmeAlan.areaColor()[i])
							{
								case 1:
									c.ForeColor = Color.LawnGreen;
									c.BackColor = Color.LawnGreen;
									break;
								case 2:
									c.ForeColor = Color.OrangeRed;
									c.BackColor = Color.OrangeRed;
									break;
								case 3:
									c.ForeColor = Color.Blue;
									c.BackColor = Color.Blue;
									break;
								default:
									c.ForeColor = Color.White;
									c.BackColor = Color.White;
									break;
							}
						}
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (ok2)
			{
				ok2 = false;
				panel3.Visible = false;
			}
			else
			{
				ok2 = true;
				panel3.Visible = true;
				istifa.Enabled = true;
				u = BLL_User.GetUser(userid);
				label6.Text = u.displayPuanlar[0].ToString();
				label7.Text = u.displayPuanlar[1].ToString();
				label8.Text = u.displayPuanlar[2].ToString();
				label13.Text = BLL_Baslangic.GetBaslangic().getBaslangicGun().ToString();
				switch (BLL_User.infoJob(userid))
				{
					case 0:
						label23.Text = "Çalışmıyor";
						istifa.Visible = false;
						break;
					case 1:
						label23.Text = "Market";
						istifa.Visible = true;
						break;
					case 2:
						label23.Text = "Mağaza";
						istifa.Visible = true;
						break;
					case 3:
						label23.Text = "Emlak";
						istifa.Visible = true;
						break;
				}
			}
		}

		private void ilerle_Click(object sender, EventArgs e)
		{
			BLL_Baslangic.IncreaseDay(Convert.ToInt32(gun.Text));
			BLL_User.DayResults(Convert.ToInt32(gun.Text));
			BLL_Calisan.payIt(Convert.ToInt32(gun.Text));
		}

		private void button10_Click(object sender, EventArgs e)
		{
			if(u.getCalismaDurumu())
			{
				label18.Text = "Zaten bir işte çalışıyorsunuz";
				label18.ForeColor = Color.Red;
			}
			else
			{
				panel13.Visible = true;
				Market m = BLL_Market.getMarketAttributies(Convert.ToInt32(marketid.Text));
				label21.Text = m.getMarketMaas().ToString();
				label22.Text = m.getMarketCalismaSaati().ToString();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			DataTable dt = BLL_Market.getTableMarket();
			dataGridView1.DataSource = dt;
			panel10.Visible = true;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			panel10.Visible = false;
			label18.Text = null;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			if(BLL_User.BuyFood(userid, Convert.ToInt32(marketid.Text), Convert.ToInt32(miktar.Text)))
			{
				label18.Text = "Satın Alındı";
				label18.ForeColor = Color.DarkGreen;
			}
			else
			{
				label18.Text = "Satın Alınamadı";
				label18.ForeColor = Color.Red;
			}
		}

		private void label17_Click(object sender, EventArgs e)
		{

		}

		private void panel12_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button12_Click(object sender, EventArgs e)
		{
			panel13.Visible = false;
		}

		private void button11_Click(object sender, EventArgs e)
		{
			Market m = BLL_Market.getMarketAttributies(Convert.ToInt32(marketid.Text));
			BLL_User.GetJob(userid, Convert.ToInt32(marketid.Text), m.getMarketCalismaSaati());
			label18.Text = "İşe Girdiniz !";
			label18.ForeColor = Color.DarkGreen;
			panel13.Visible = false;
		}

		private void label21_Click(object sender, EventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
			DataTable dt = BLL_Magaza.getMagazaTable();
			dataGridView2.DataSource = dt;
			magazapanel.Visible = true;
		}

		private void button5_Click(object sender, EventArgs e)
		{
			magazapanel.Visible = false;
			label33.Text = null;
		}

		private void button13_Click(object sender, EventArgs e)
		{
			magazapanel2.Visible = true;
			Mağaza m = BLL_Magaza.getMagazaAttributes(Convert.ToInt32(magazaid.Text));
			label29.Text = m.getMagazaMaas().ToString();
			label28.Text = m.getMagazaCalismaSaati().ToString();
		}

		private void button16_Click(object sender, EventArgs e)
		{
			Mağaza m = BLL_Magaza.getMagazaAttributes(Convert.ToInt32(magazaid.Text));
			BLL_User.GetJob(userid, Convert.ToInt32(magazaid.Text), m.getMagazaCalismaSaati());
			label33.Text = "İşe Girdiniz";
			magazapanel2.Visible = false;
		}

		private void istifa_Click(object sender, EventArgs e)
		{
			if(BLL_User.resignationJob(userid))
			{
				istifa.Enabled = false;
			}
		}

		private void button15_Click(object sender, EventArgs e)
		{
			magazapanel2.Visible = false;
		}

		private void button14_Click(object sender, EventArgs e)
		{
			if(BLL_User.buyFurniture(userid,Convert.ToInt32(magazaid.Text), Convert.ToInt32(mmiktar.Text)))
			{
				label33.Text = "Satın Alındı";
				label33.ForeColor = Color.DarkGreen;
			}
			else
			{
				label33.Text = "Satın Alınamadı";
				label33.ForeColor = Color.Red;
			}
		}

		private void area0_Click(object sender, EventArgs e)
		{
			ForeColor = Color.Violet; BackColor = Color.Violet;
		}

		private void button19_Click(object sender, EventArgs e)
		{
			BLL_User.resetUsers();
			BLL_Baslangic.resetDay();
			Application.Exit();

		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void button8_Click(object sender, EventArgs e)
		{
			emlaklarpanel.Visible = true;
			DataTable dt = BLL_Emlak.getEmlakTable();
			dataGridView3.DataSource = dt;

		}

		private void button7_Click(object sender, EventArgs e)
		{
			emlaklarpanel.Visible = false;
			textBox2.Text = null;
		}

		private void button20_Click(object sender, EventArgs e)
		{
			List<İşletmeAlan> list = BLL_IsletmeAlan.getBusinessAreasList(Convert.ToInt32(emlakid.Text));

			foreach (İşletmeAlan i in list)
			{
				foreach (Control c in arazi)
				{
					if (c.Name.Contains(i.getAlanIDS()) && !i.getAlanTur())
					{
						c.Enabled = true;
						c.ForeColor = Color.Silver; c.BackColor = Color.LightGray;
					}
				}
			}

		}

		private void area38_Click(object sender, EventArgs e)
		{
			foreach (Control c in arazi)
			{
				if (c.Name.Contains("38"))
				{
					c.ForeColor = Color.Violet; c.BackColor = Color.Violet;
				}
			}
			alansecme++;
			textBox2.Text += "38";
			textBox1.Text += "38";
			if (alansecme == 2)
			{
				button_close();
			}
		}

		private void area06_Click(object sender, EventArgs e)
		{
			foreach (Control c in arazi)
			{
				if (c.Name.Contains("06"))
				{
					c.ForeColor = Color.Violet; c.BackColor = Color.Violet;
				}
			}
			alansecme++;
			textBox2.Text += "06";
			textBox1.Text += "06";
			if (alansecme == 2)
			{
				button_close();
			}

		}

		private void area07_Click(object sender, EventArgs e)
		{
			foreach (Control c in arazi)
			{
				if (c.Name.Contains("07"))
				{
					c.ForeColor = Color.Violet; c.BackColor = Color.Violet;
				}
			}
			alansecme++;
			textBox2.Text += "07";
			textBox1.Text += "07";
			if (alansecme == 2)
			{
				button_close();
			}

		}

		private void area08_Click(object sender, EventArgs e)
		{
			foreach (Control c in arazi)
			{
				if (c.Name.Contains("08"))
				{
					c.ForeColor = Color.Violet; c.BackColor = Color.Violet;
				}
			}
			alansecme++;
			textBox2.Text += "08";
			textBox1.Text += "08";
			if (alansecme == 2)
			{
				button_close();
			}

		}

		private void area09_Click(object sender, EventArgs e)
		{
			foreach (Control c in arazi)
			{
				if (c.Name.Contains("09"))
				{
					c.ForeColor = Color.Violet; c.BackColor = Color.Violet;
				}
			}
			alansecme++;
			textBox2.Text += "09";
			textBox1.Text += "09";
			if (alansecme == 2)
			{
				button_close();
			}
		}

		private void button_close()
		{
			foreach(Control c in arazi)
			{
				c.Enabled = false;
			}
			alansecme = 0;
			button24.Visible = true;
		}

		private void label38_Click(object sender, EventArgs e)
		{

		}

		private void button21_Click(object sender, EventArgs e)
		{
			Emlak k = BLL_Emlak.getEmlakAttributes(Convert.ToInt32(emlakid.Text));
			label40.Text = k.getMaas().ToString();
			label39.Text = k.getGunlukSaat().ToString();
			emlaklarpanel2.Visible = true;
		}

		private void button24_Click(object sender, EventArgs e)
		{
			if(BLL_Emlak.getEmlakPrice(Convert.ToInt32(emlakid.Text)) > u.getParaMiktarı())
			{
				label43.Text = "Arsa Satın Almak İçin Yeterli Para Yok";
				label43.ForeColor = Color.Red;
				button24.Visible = false;
			}
			else
			{
				if (BLL_IsletmeAlan.buyArea(userid, textBox2.Text))
				{
					label43.Text = "Arsa Satın Alındı";
					label43.ForeColor = Color.Green;
					button24.Visible = false;
				}
				else
				{
					label43.Text = "Arsa Satın Alınamadı";
					label43.ForeColor = Color.Red;
					button24.Visible = false;
				}
			}
			
		}

		private void area99_Click(object sender, EventArgs e)
		{
			foreach (Control c in arazi)
			{
				if (c.Name.Contains("99"))
				{
					c.ForeColor = Color.Violet; c.BackColor = Color.Violet;
				}
			}
			alansecme++;
			textBox2.Text += "99";
			if (alansecme == 2)
			{
				button_close();
			}
		}

		private void area98_Click(object sender, EventArgs e)
		{
			foreach (Control c in arazi)
			{
				if (c.Name.Contains("98"))
				{
					c.ForeColor = Color.Violet; c.BackColor = Color.Violet;
				}
			}
			alansecme++;
			textBox2.Text += "98";
			if (alansecme == 2)
			{
				button_close();
			}
		}

		private void button22_Click(object sender, EventArgs e)
		{
			emlaklarpanel2.Visible = false;
		}

		private void button23_Click(object sender, EventArgs e)
		{
			Emlak k = BLL_Emlak.getEmlakAttributes(Convert.ToInt32(emlakid.Text));
			BLL_User.GetJob(userid, Convert.ToInt32(emlakid.Text), k.getGunlukSaat());
			emlaklarpanel2.Visible = false;
		}

		private void button28_Click(object sender, EventArgs e)
		{
			List<İşletmeAlan> areas = BLL_IsletmeAlan.getBusinessAreasListbyUser(userid);

			foreach(Control c in arazi)
			{
				foreach(İşletmeAlan i in areas)
				{
					if(c.Name.Contains(i.getAlanIDS()))
					{
						c.Enabled = true;
					}
				}
			}
		}

		private void button26_Click(object sender, EventArgs e)
		{
			if(u.getParaMiktarı() < 3000)
			{
				label54.Text = "Paranız Yeterli Değil";
				label54.ForeColor = Color.Red;
			}
			else
			{
				BLL_User.downMoney(3000, userid);
				if(BLL_IsletmeAlan.convertArea(textBox1.Text, userid, 3))
				{
					label54.Text = "İşletmeniz Açıldı";
					label54.ForeColor = Color.DarkGreen;
				}
				else
				{
					label54.Text = "İşletmeniz Açılamadı";
					label54.ForeColor = Color.Red;
				}
			}
		}

		private void button18_Click(object sender, EventArgs e)
		{
			isletmeac.Visible = true;
		}

		private void button17_Click(object sender, EventArgs e)
		{
			isletmeac.Visible = false;
			textBox1.Text = null;
		}

		private void button25_Click(object sender, EventArgs e)
		{
			if (u.getParaMiktarı() < 2750)
			{
				label54.Text = "Paranız Yeterli Değil";
				label54.ForeColor = Color.Red;
			}
			else
			{
				BLL_User.downMoney(2750, userid);
				if (BLL_IsletmeAlan.convertArea(textBox1.Text, userid, 2))
				{
					label54.Text = "İşletmeniz Açıldı";
					label54.ForeColor = Color.DarkGreen;
				}
				else
				{
					label54.Text = "İşletmeniz Açılamadı";
					label54.ForeColor = Color.Red;
				}
			}
		}

		private void button27_Click(object sender, EventArgs e)
		{
			if (u.getParaMiktarı() < 2500)
			{
				label54.Text = "Paranız Yeterli Değil";
				label54.ForeColor = Color.Red;
			}
			else
			{
				BLL_User.downMoney(2500, userid);
				if (BLL_IsletmeAlan.convertArea(textBox1.Text, userid, 1))
				{
					label54.Text = "İşletmeniz Açıldı";
					label54.ForeColor = Color.DarkGreen;
				}
				else
				{
					label54.Text = "İşletmeniz Açılamadı";
					label54.ForeColor = Color.Red;
				}
			}
		}

		private void button29_Click(object sender, EventArgs e)
		{
			if(BLL_Isletmeler.amIBoss(userid))
			{
				isletmeac2.Visible = true;
			}
			{
				isletmeac2.Visible = false;
				label54.Text = "İşletmeniz Yok";
				label54.ForeColor = Color.Red;
			}
		}

		private void button31_Click(object sender, EventArgs e)
		{
			isletmeac2.Visible = false;
			textBox3.Text = null;
		}

		private void button30_Click(object sender, EventArgs e)
		{

		}
	}
}
