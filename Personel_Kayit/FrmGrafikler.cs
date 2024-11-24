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

namespace Personel_Kayit
{
    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ELYASA\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True;");

        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            //grafik1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select Persehir, count(*) from tbl_personel group by persehir", baglanti);
            SqlDataReader dr1= komutg1.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();

            //grafik2
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select PerMeslek, Avg(PerMaas) from tbl_personel group by PerMeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();

            ////grafik3
            //baglanti.Open();
            //SqlCommand komutg3 = new SqlCommand("Select Perdurum, count(*) from tbl_personel group by perdurum", baglanti);
            //SqlDataReader dr3 = komutg3.ExecuteReader();
            //while (dr3.Read())
            //{
            //    chart3.Series["Evli-Bekar"].Points.AddXY(dr3[0], dr3[1]);
            //}
            //baglanti.Close();
        }
    }
}
