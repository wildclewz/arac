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
    public partial class aracliste : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OUJMK5A\SQLEXPRESS;Initial Catalog=araçkira;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        public aracliste()
        {
            InitializeComponent();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow satir = dataGridView1.CurrentRow;
            textBox1.Text = satir.Cells["plaka"].Value.ToString();
            textBox2.Text = satir.Cells["marka"].Value.ToString();
            textBox3.Text = satir.Cells["seri"].Value.ToString(); 
            textBox4.Text = satir.Cells["yıl"].Value.ToString();
            textBox5.Text = satir.Cells["renk"].Value.ToString();
            textBox6.Text = satir.Cells["km"].Value.ToString();
            textBox7.Text = satir.Cells["yakıt"].Value.ToString();
            textBox8.Text = satir.Cells["kiraucret"].Value.ToString();
        }

        private void aracliste_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void yenile()
        {
            con.Open();
            adpt = new SqlDataAdapter("select * from cars", con);
            dt = new DataTable();
            adpt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        { try
            {
                con.Open();
                string cmd = "uptade cars set marka=@marka,seri=@seri,yıl=@yıl,renk=@renk,km=@km,yakıt=@yakıt,kiraucret=@kiraucret,tarih=@tarih where plaka=@plaka ";
                SqlCommand giris = new SqlCommand();
                giris.Parameters.AddWithValue("@plaka", textBox1.Text);
                giris.Parameters.AddWithValue("@marka", textBox2.Text);
                giris.Parameters.AddWithValue("@seri", textBox3.Text);
                giris.Parameters.AddWithValue("@yıl", textBox4.Text);
                giris.Parameters.AddWithValue("@renk", textBox5.Text);
                giris.Parameters.AddWithValue("@yakıt", textBox6.Text);
                giris.Parameters.AddWithValue("@kiraucret",textBox7.Text);           
               giris.ExecuteNonQuery();
                foreach (Control item in Controls) if (item is TextBox) item.Text = "";
                MessageBox.Show("güncellenmiştir");
                con.Close();
                yenile();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
           
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                DataGridViewRow satir = dataGridView1.CurrentRow;
                string cmd = "delete from cars where plaka='" + satir.Cells["plaka"].Value.ToString() + "'";
                SqlCommand giris = new SqlCommand();
                giris.ExecuteNonQuery();
                MessageBox.Show("kişi silinmiştir");
                con.Close();
                yenile();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
    }
}
