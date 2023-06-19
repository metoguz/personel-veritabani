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
    public partial class anaform : Form
    {
        public anaform()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=Melih\\SQLEXPRESS01;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        void temizle()
        {
            textad.Text = "";
            textsoyad.Text = "";
            textsehir.Text = "";
            mtextmaas.Text = "";
            textmeslek.Text = "";
            radioButton1.Checked = false; radioButton2.Checked=false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet4.Tbl_per' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.tbl_perTableAdapter2.Fill(this.personelVeriTabaniDataSet4.Tbl_per);
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet3.Tbl_per' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
           
            // TODO: Bu kod satırı 'personelVeriTabaniDataSet1.Tbl_per' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) { 
                label7.Text = ("False");
        }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from Tbl_per where perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1",textid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kayıt silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_per (perad,persoyad,persehir,permaas,perdurum,permeslek) values(@p1,@p2,@p3,@p4,@p5,@p6)",baglanti);
            komut.Parameters.AddWithValue("@p1", textad.Text);
            komut.Parameters.AddWithValue("@p2", textsoyad.Text);
            komut.Parameters.AddWithValue("@p3", textsehir.Text);
            komut.Parameters.AddWithValue("@p4", mtextmaas.Text);
            komut.Parameters.AddWithValue("@p5", label7.Text);
            komut.Parameters.AddWithValue("@p6", textmeslek.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.tbl_perTableAdapter2.Fill(this.personelVeriTabaniDataSet4.Tbl_per);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label7.Text = ("True");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen= dataGridView1.SelectedCells[0].RowIndex;
            textid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mtextmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label7.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            textmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();


        }

        private void label7_TextChanged(object sender, EventArgs e)
        {
            if(label7.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if(label7.Text== "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle= new SqlCommand("Update tbl_per set PerAd=@a1,PerSoyad=@a2,PerSehir=@a3, PerMaas=@a4, PerDurum=@a5 ,PerMeslek=@a6 where Perid=@a7",baglanti);
            komutguncelle.Parameters.AddWithValue("@a1",textad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", textsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", textsehir.Text);
            komutguncelle.Parameters.AddWithValue("@a4", mtextmaas.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label7.Text);
            komutguncelle.Parameters.AddWithValue("@a6", textmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7",textid.Text);
            komutguncelle.ExecuteNonQuery();
            MessageBox.Show("Personel Bilgisi Güncellendi");

            baglanti.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 fr= new Form3();  
            fr.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            chart fr = new chart();
            fr.Show();
        }
    }
}
