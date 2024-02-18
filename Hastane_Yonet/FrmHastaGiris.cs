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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        Sqlbaglantisi bgl=new Sqlbaglantisi();  //sql sınıfını çağırıp database bağlanmak için.

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frm=new FrmHastaKayit();
            frm.Show();
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut =new SqlCommand("Select * From Tbl_Hastalar Where HastaTc=@a1 and HastaSifre=@a2",bgl.baglanti());
            komut.Parameters.AddWithValue("@a1", MskTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@a2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader(); //komuttan gelen verileri oku
            if (dr.Read()) //kontrol sağlanırken if. kontrol sağlanıp yazdırma olursa while.
            {
                FrmHastaDetay frm=new FrmHastaDetay();
                frm.tc = MskTcKimlikNo.Text; //HastaGiris formunda ki tc yi hastaDetay formundaki fr değişkenine ata.
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı TC veya Şifre !", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            bgl.baglanti().Close();
        }
    }
}
