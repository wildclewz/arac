using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace araçkira
{
    public partial class adminpanel : Form
    {
        public adminpanel()
        {
            InitializeComponent();
            displaydata();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OUJMK5A\SQLEXPRESS;Initial Catalog=araçkira;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        DataTable dt;
        int Usersid;
        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }
      


        private void button8_Click_1(object sender, EventArgs e)
        {try { 
            con.Open();
                string cmd = "insert into Users(name,surname,email,telephone,Uid)" + " values (@name,@surname,@email,@telephone,@Uid)";
                SqlCommand gırıs = new SqlCommand(cmd, con);
                gırıs.Parameters.AddWithValue("@name", textBox1.Text);
                gırıs.Parameters.AddWithValue("@surname", textBox2.Text);
                gırıs.Parameters.AddWithValue("@email", textBox3.Text);
                gırıs.Parameters.AddWithValue("@telephone", textBox4.Text);
                gırıs.Parameters.AddWithValue("@Uid", comboBox1.SelectedIndex);
                gırıs.ExecuteNonQuery();
                MessageBox.Show("kayıt edilmiştir.");
            con.Close();
                displaydata();
                clear();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void displaydata()
        {
            try
            {
                con.Open();
                adpt = new SqlDataAdapter("select * from Users", con);
                dt = new DataTable();
                adpt.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        public void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox0.Text=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd=new SqlCommand("delete from Users where id='"+ Usersid+"'", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("kişi silinmiştir");
            con.Close();
            displaydata();
        }
         private void cbvahile()
        {
            con.Open();
            cmd = new SqlCommand("select * from UsersStatu ", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader["UsersStatu"]);

            }
            con.Close();
        }


        private void adminpanel_Load(object sender, EventArgs e)
        {
            cbvahile();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            con.Close();
               // string baglantıı = @"Data Source=DESKTOP-OUJMK5A\SQLEXPRESS;Initial Catalog=araçkira;Integrated Security=True";
                //string gırıs = "uptade Users set name='" + this.textBox1.Text + "',surname='" + this.textBox2.Text + "',email='" + this.textBox3.Text + "',telephone='" + this.textBox4.Text + "' where id='"+ this.textBox0.Text+"' ;";
                string gırıs = "uptade Users set name='"+this.textBox1.Text+"',surname='"+this.textBox2.Text+"',email='"+this.textBox3.Text+"',telephone='"+this.textBox4.Text+"' where id="+comboBox1.SelectedIndex;
              //  SqlConnection con = new SqlConnection(baglantı);
                SqlCommand komut_uptade = new SqlCommand (gırıs, con);
                SqlDataReader oku;
            try
            {
                con.Open();
                oku = komut_uptade.ExecuteReader();
                MessageBox.Show("güncellenmiştir.");
                con.Close();
            }catch (Exception ex) {MessageBox.Show(ex.Message); }
            displaydata();
            clear();
        }

        private void textBox0_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            arackayit kayit = new arackayit();
            kayit.Show();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            aracliste liste  = new aracliste();
            liste.Show();
        }
    }
    
}
