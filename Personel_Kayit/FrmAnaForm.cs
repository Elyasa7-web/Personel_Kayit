using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Personel_Kayit
{
    public partial class FrmAnaForm : Form
    {
        public FrmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=ELYASA\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        void temizle()
        {
            txtİd.Text = "";
            txtAd.Text = "";
            txtsoyad.Text = "";
            cmbsehir.Text = "";
            mskmaas.Text = "";
            txtmeslek.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelVeriTabaniDataSet.Tbl_Personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_Personel (perad,persoyad,persehir,permaas,permeslek,perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", mskmaas.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked== true)
            {
                label8.Text = "False";
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtİd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskmaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
          
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel Where perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1", txtİd.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi!");
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutgüncelle = new SqlCommand("Update Tbl_Personel Set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7", baglanti);
            komutgüncelle.Parameters.AddWithValue("@a1", txtAd.Text);
            komutgüncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutgüncelle.Parameters.AddWithValue("@a3", cmbsehir.Text);
            komutgüncelle.Parameters.AddWithValue("@a4", mskmaas.Text);
            komutgüncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutgüncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutgüncelle.Parameters.AddWithValue("@a7", txtİd.Text);
            komutgüncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgileri Güncellendi!");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frm_istatistik fr = new Frm_istatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmRaporlar frp = new FrmRaporlar();
            frp.Show();
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
