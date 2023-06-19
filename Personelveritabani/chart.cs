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
    public partial class chart : Form
    {
        public chart()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Melih\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void chart_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("select persehir,count(*) from tbl_per group by persehir",baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart2.Series["sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("select permeslek,avg(permaas) from tbl_per group by permeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["ortalamamaas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();
        }

    }
}
