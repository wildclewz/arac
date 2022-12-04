using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;

namespace araçkira
{
    public partial class arackayit : Form
    { 
      
        public arackayit()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OUJMK5A\SQLEXPRESS;Initial Catalog=araçkira;Integrated Security=True");

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            try
            {
                
                string cmd = "insert into cars(plaka,marka,seri,yıl,renk,km,yakıt,kiraucret,tarih,durumu) values (@plaka,@marka,@seri,@yıl,@renk,@km,@yakıt,@kiraucret,@tarih,@durumu)";
                SqlCommand giris = new SqlCommand(cmd, con);
                giris.Parameters.AddWithValue("@plaka", textBox1.Text);
                giris.Parameters.AddWithValue("@marka", textBox2.Text);
                giris.Parameters.AddWithValue("@seri", textBox3.Text);
                giris.Parameters.AddWithValue("@yıl", textBox4.Text);
                giris.Parameters.AddWithValue("@renk", textBox5.Text);
                giris.Parameters.AddWithValue("@km", textBox6.Text);
                giris.Parameters.AddWithValue("@yakıt", textBox7.Text);
                giris.Parameters.AddWithValue("@kiraucret", textBox8.Text);
                giris.Parameters.AddWithValue("@tarih", DateTime.Now.ToString());
                giris.Parameters.AddWithValue("@durumu", "boş");
                con.Open();
                giris.ExecuteNonQuery();
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                MessageBox.Show("kayıt olmuştur");
                con.Close();

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

     
    }
}
