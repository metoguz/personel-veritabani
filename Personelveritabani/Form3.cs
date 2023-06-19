using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Personelveritabani
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Melih\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select count (*) from tbl_per", baglanti);
            SqlDataReader dr1= komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplamper.Text = dr1[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select count (*) from tbl_per where perdurum=1",baglanti);
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read())
            {
                lblevl.Text = dr2[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select count(*) from tbl_per where perdurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblbekar.Text = dr3[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select sum (permaas) from tbl_per",baglanti);
            SqlDataReader dr4= komut4.ExecuteReader();
            while (dr4.Read())
            {
                lbltmaas.Text = dr4[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select avg (permaas) from tbl_per", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblomaas.Text = dr5[0].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select count (distinct(persehir)) from tbl_per",baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblsehirsayisi.Text = dr6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
