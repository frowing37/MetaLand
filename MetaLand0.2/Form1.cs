using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer_ML;
using EntityLayer_ML;

namespace MetaLand0._2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			User u = BLL_User.Login(textBox1.Text, textBox2.Text);

			if (u != null)
			{
				label5.Text = "Başarılı";
				label5.ForeColor = Color.Lime;
				textBox1.Text = null;
				textBox2.Text = null;
				if(u.isAdmin())
				{
					Form3 adminScreen = new Form3(u.ID);
					adminScreen.Show();
				}
				else
				{
					Form2 gameScreen = new Form2(u.ID);
					gameScreen.Show();
				}
			}

			else
			{
				label5.Text = "Başarısız";
				label5.ForeColor = Color.Red; 
			}

		}

		private void button2_Click(object sender, EventArgs e)
		{
			int goal = BLL_User.SignUp(textBox1.Text, textBox2.Text);

			switch(goal)
			{
				case 1:

					label5.Text = "Kayıt Başarılı";
					label5.ForeColor = Color.Lime;
					break;

				case 0:

					label5.Text = "Alanlar Boş \n Bırakılamaz";
					label5.ForeColor = Color.Red;
					break;

				case -1:

					label5.Text = "Kayıt Başarısız";
					label5.ForeColor = Color.Red;
					break;
			}

			textBox1.Text = null;
			textBox2.Text = null;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			
		}
	}
}
