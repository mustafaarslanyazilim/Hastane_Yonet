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

namespace Hastane_Yonet
{
    public partial class FrmBilgiDuzenle : Form
    {
        public FrmBilgiDuzenle()
        {
            InitializeComponent();
        }
        public string TCno;
        Sqlbaglantisi bgl = new Sqlbaglantisi();
        private void FrmBilgiDuzenle_Load(object sender, EventArgs e)
        {
            MskTcKimlikNo.Text = TCno;
            SqlCommand komut = new SqlCommand("select * From Tbl_Hastalar where HastaTC=@a1", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", MskTcKimlikNo.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                MskTelefon.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();
                CmbCinsiyet.Text = dr[6].ToString();
            }
            bgl.baglanti().Close();
        }

        private void BtnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@a1, HastaSoyad=@a2, HastaTelefon=@a3, HastaSifre=@a4,HastaCinsiyet=@a5 where HastaTc=@a6", bgl.baglanti());
            komut2.Parameters.AddWithValue("@a1", TxtAd.Text);
            komut2.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@a3", MskTelefon.Text);
            komut2.Parameters.AddWithValue("@a4", TxtSifre.Text);
            komut2.Parameters.AddWithValue("@a5", CmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@a6",MskTcKimlikNo.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti() .Close();
            MessageBox.Show("Bilgileriniz Güncellendi","Bilgi",MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
