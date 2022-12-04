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
using System.Security.Cryptography;


namespace araçkira
{
    public partial class kayıt : Form
    {
        private string Md5(string text)
        {
            MD5 MD5Encrypting = new MD5CryptoServiceProvider();
            byte[] bytes = MD5Encrypting.ComputeHash(Encoding.UTF8.GetBytes(text.ToCharArray()));

            StringBuilder builder = new StringBuilder();


            foreach (var item in bytes)
            {
                builder.Append(item.ToString("x2"));
            }





            return builder.ToString();

        }
        public kayıt()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OUJMK5A\SQLEXPRESS;Initial Catalog=araçkira;Integrated Security=True");
        private void Kayit_Click(object sender, EventArgs e)
        {   try
            {
                string cmd = "insert into Users(name,surname,email,password,telephone,Uid)values(@name,@surname,@email,@password,@telephone,@Uid)";
                SqlCommand k = new SqlCommand(cmd, con);
                k.Parameters.AddWithValue("@name", textBox1.Text);
                k.Parameters.AddWithValue("@surname", textBox2.Text);
                k.Parameters.AddWithValue("@email", textBox3.Text);
                k.Parameters.AddWithValue("@password", Md5(textBox4.Text));
                k.Parameters.AddWithValue("@telephone", textBox5.Text);
                k.Parameters.AddWithValue("@Uid", 1);
                con.Open();
                k.ExecuteNonQuery();
                MessageBox.Show("Kaydınız başarıyla olmuştur");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                con.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
