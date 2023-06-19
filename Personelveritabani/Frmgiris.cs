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

namespace Personelveritabani
{
    public partial class Frmgiris : Form
    {
        public Frmgiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Melih\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void btngrs_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from tbl_yonetici where kullaniciad=@p1 and sifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1",txtkullaniciad.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dataReader= komut.ExecuteReader();
            if (dataReader.Read())
            {
                anaform fr= new anaform();
                fr.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("kullanici adi veya sifre hatalidir");

            }
            baglanti.Close();


        }
    }
}
