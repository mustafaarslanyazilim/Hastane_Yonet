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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }
        Sqlbaglantisi bgl = new Sqlbaglantisi();

        private void BtnKayitYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Hastalar(HastaAd,HastaSoyad,HastaTc,HastaTelefon,HastaSifre,HastaCinsiyet) values (@a1,@a2,@a3,@a4,@a5,@a6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", TxtAd.Text);
            komut.Parameters.AddWithValue("@a2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@a3", MskTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@a4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@a5", TxtSifre.Text);
            komut.Parameters.AddWithValue("@a6", CmbCinsiyet.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir. Şifreniz: " + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
