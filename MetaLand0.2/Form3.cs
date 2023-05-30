using BusinessLogicLayer_ML;
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
using System.Data.SqlClient;

namespace MetaLand0._2
{
	public partial class Form3 : Form
	{
		int adminid;
		public Form3(int id)
		{
			InitializeComponent();
			adminid = id;
		}

		private void Form3_Load(object sender, EventArgs e)
		{
			User admin = BLL_User.GetUser(adminid);
			label2.Text = admin.ID.ToString();
			label4.Text = admin.displayAd.ToString();
			label6.Text = admin.displaySoyad.ToString();
		}

		private void button3_Click(object sender, EventArgs e)
		{
			kullanıcılarpanel.Visible = true;
			kullanıcılar2panel.Visible = true;
			DataTable dt = BLL_User.GetUserList();
			dataGridView1.DataSource = dt;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			baslangicpanel.Visible = false;
		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void label8_Click(object sender, EventArgs e)
		{

		}

		private void panel9_Paint(object sender, PaintEventArgs e)
		{

		}

		private void button6_Click(object sender, EventArgs e)
		{
			isletmelerpanel.Visible = true;
			isletmelerpanel2.Visible = true;
			DataTable dt = BLL_Isletmeler.GetTableIsletme();
			dataGridView3.DataSource = dt;

		}

		private void button5_Click(object sender, EventArgs e)
		{
			isletmelerpanel.Visible = false;
			isletmelerpanel2.Visible = false;
		}

		private void button8_Click(object sender, EventArgs e)
		{
			calisanlarpanel.Visible = true;
			calisanlarpanel2.Visible = true;
			DataTable dt = BLL_Calisan.GetCalisanList();
			dataGridView2.DataSource = dt;
		}

		private void button7_Click(object sender, EventArgs e)
		{
			calisanlarpanel.Visible = false;
			calisanlarpanel2.Visible = false;
		}

		private void button10_Click(object sender, EventArgs e)
		{
			baslangicpanel.Visible = true;
		}

		private void button9_Click(object sender, EventArgs e)
		{
			baslangicpanel.Visible = false;
		}

		private void button4_Click_1(object sender, EventArgs e)
		{
			kullanıcılarpanel.Visible = false;
			kullanıcılar2panel.Visible = false;
			label24.Text = null;
		}

		private void button11_Click(object sender, EventArgs e)
		{
			if (BLL_User.UpdateColumnsDefault("UserYemekMiktarı", textBox1.Text))
			{
				label14.Text = "Güncellendi";
				label14.ForeColor = Color.Lime;
			}

			else
			{
				label14.Text = "Güncellenemedi";
				label14.ForeColor = Color.Red;
			}
		}

		private void button12_Click(object sender, EventArgs e)
		{
			if (BLL_User.UpdateColumnsDefault("UserParaMiktarı", textBox2.Text))
			{
				label14.Text = "Güncellendi";
				label14.ForeColor = Color.Lime;
			}

			else
			{
				label14.Text = "Güncellenemedi";
				label14.ForeColor = Color.Red;
			}
		}

		private void button13_Click(object sender, EventArgs e)
		{
			if(BLL_User.UpdateColumnsDefault("UserEşyaMiktarı", textBox3.Text))
			{
				label14.Text = "Güncellendi";
				label14.ForeColor = Color.Lime;
			}

			else
			{
				label14.Text = "Güncellenemedi";
				label14.ForeColor = Color.Red;
			}
		}

		private void label15_Click(object sender, EventArgs e)
		{

		}

		private void button14_Click(object sender, EventArgs e)
		{
			if(BLL_User.UpdateUser(Convert.ToInt32(textBox4.Text), textBox5.Text, textBox6.Text, textBox7.Text, Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), Convert.ToInt32(textBox10.Text), Convert.ToDateTime(dateTimePicker1.Text), checkBox1.Checked))
			{
				label24.Text = "Güncellendi";
				label24.ForeColor = Color.DarkGreen;
			}
			else
			{
				label24.Text = "Güncellenemedi";
				label24.ForeColor = Color.Red;
			}
		}

		private void label18_Click(object sender, EventArgs e)
		{

		}

		private void label20_Click(object sender, EventArgs e)
		{

		}

		private void button15_Click(object sender, EventArgs e)
		{
			if(BLL_User.DeleteUser(Convert.ToInt32(textBox4.Text)))
			{
				label24.Text = "Silindi";
				label24.ForeColor = Color.DarkGreen;
			}
			else
			{
				label24.Text = "Silinemedi";
				label24.ForeColor = Color.Red;
			}
		}

		private void label26_Click(object sender, EventArgs e)
		{

		}

		private void baslangicxy_Click(object sender, EventArgs e)
		{
			int x = Convert.ToInt32(textBox11.Text);
			int y = Convert.ToInt32(textBox12.Text);

			if(BLL_Baslangic.UpdateXY(x,y))
			{
				label14.Text = "Güncellendi";
				label14.ForeColor = Color.Lime;
			}
			else
			{
				label14.Text = "Güncellenemedi";
				label14.ForeColor = Color.Red;
			}

		}

		private void button11_Click_1(object sender, EventArgs e)
		{
			if(BLL_Calisan.UpdateCalisan(Convert.ToInt32(textBox19.Text),Convert.ToDateTime(dateTimePicker2),Convert.ToDateTime(dateTimePicker3),Convert.ToInt32(textBox17.Text), Convert.ToInt32(textBox18.Text),Convert.ToInt32(textBox13.Text)))
			{
				label28.Text = "Güncellendi";
				label28.ForeColor = Color.DarkGreen;
			}
			else
			{
				label28.Text = "Güncellenemedi";
				label28.ForeColor = Color.Red;
			}
		}

		private void button12_Click_1(object sender, EventArgs e)
		{
			if(BLL_Calisan.DeleteCalisan(Convert.ToInt32(textBox13.Text)))
			{
				label28.Text = "Güncellendi";
				label28.ForeColor = Color.DarkGreen;
			}
			else
			{
				label28.Text = "Güncellenemedi";
				label28.ForeColor = Color.Red;
			}
		}

		private void button13_Click_1(object sender, EventArgs e)
		{
			if(BLL_Isletmeler.UpdateIsletme(Convert.ToInt32(textBox14.Text), Convert.ToInt32(textBox15.Text), Convert.ToInt32(textBox16.Text), Convert.ToInt32(textBox20.Text), Convert.ToInt32(textBox24.Text), Convert.ToInt32(textBox25.Text), Convert.ToInt32(textBox21.Text), Convert.ToInt32(textBox23.Text), Convert.ToInt32(textBox22.Text), Convert.ToInt32(textBox26.Text), Convert.ToInt32(textBox27.Text)))
			{
				label45.Text = "Güncellendi";
				label45.ForeColor = Color.DarkGreen;
			}

			else
			{
				label45.Text = "Güncellenemedi";
				label45.ForeColor = Color.Red;
			}
		}

		private void button16_Click(object sender, EventArgs e)
		{
			if(BLL_Isletmeler.DeleteIsletme(Convert.ToInt32(textBox14.Text)))
			{
				label45.Text = "Güncellendi";
				label45.ForeColor = Color.DarkGreen;
			}
			else
			{
				label45.Text = "Güncellenemedi";
				label45.ForeColor = Color.Red;
			}
		}
	}
}
