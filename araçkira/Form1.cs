using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.Sql;
using System.Data.SqlClient;


namespace araçkira
{
    public partial class Form1 : Form
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

        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-OUJMK5A\SQLEXPRESS;Initial Catalog=araçkira;Integrated Security=True");
        private void Kayıt_Click(object sender, EventArgs e)
        {
            kayıt frm = new kayıt();
            frm.Show();

        }

        private void Giriş_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("boş bırakma lan");
            }
            else
            {
                try
                {
                    con.Open();
                    SqlCommand giris = new SqlCommand("select * from Users where email='" + textBox1.Text.Trim() + "' and password='" + Md5(textBox2.Text) + "'", con);
                    SqlDataReader oku = giris.ExecuteReader();

                     if(oku.Read())
                    {
                        if (oku["Uid"].ToString() == "0")
                        {
                            adminpanel admı = new adminpanel();
                            admı.Show();
                            con.Close();   
                        }
            else if (oku["Uid"].ToString() == "1")
                        {
                            Userspanel users = new Userspanel();
                            users.Show();
                            con.Close();
                        }
                    }
                     else
                    {
                        MessageBox.Show("hatalı giriş düzelt gel");
                        con.Close();                    
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                }catch (Exception ex) {MessageBox.Show(ex.Message); }
          
            
             }
         
        
        }
        



      
    }
}