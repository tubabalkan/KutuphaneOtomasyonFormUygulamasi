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

namespace KütüphaneOtomasyon
{
    public partial class UyeListelemeFrm : Form
    {
        public UyeListelemeFrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from UyeEkleTable where tc like '"+txtTc.Text+"'",baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                txtAdSoyad.Text = read["adsoyad"].ToString();
                txtYas.Text= read["yaş"].ToString();
                comboCinsiyet.Text = read["cinsiyet"].ToString();
                txtTelefon.Text= read["telefon"].ToString();
                txtAdres.Text= read["adres"].ToString();
                txtMail.Text= read["email"].ToString();
                txtOkunanKitapSayisi.Text = read["okukitapsayısı"].ToString();
            }
            baglanti.Close();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update UyeEkleTable set  adsoyad=@adsoyad, yaş=@yaş, cinsiyet=@cinsiyet, telefon=@telefon, adres=@adres, email=@email, okukitapsayısı=@okukitapsayısı where  tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@yaş", txtYas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", comboCinsiyet.Text);
            komut.Parameters.AddWithValue("@telefon", txtTelefon.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@email", txtMail.Text);
            komut.Parameters.AddWithValue("@okukitapsayısı",int.Parse(txtOkunanKitapSayisi.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Başarılı Bir Şekilde Gerçekleşmiştir");
            daset.Tables["UyeEkleTable"].Clear();
            uyelistele();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        DataSet daset = new DataSet();
        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            daset.Tables["UyeEkleTable"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from UyeEkleTable where tc like '%" + txtTcAra.Text + "%'", baglanti);
            adtr.Fill(daset,"UyeEkleTable");
            dataGridView1.DataSource = daset.Tables["UyeEkleTable"];
            baglanti.Close();
        }

        private void btnİptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bu Kaydı Silmek Mi İstiyorsunuz?","sil", MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (dialog == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from UyeEkleTable where tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());

                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Başarılı Bir Şekilde Gerçekleştirildi.");
                daset.Tables["UyeEkleTable"].Clear();
                uyelistele();
                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }

          
        }
        private void uyelistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from UyeEkleTable", baglanti);
            adtr.Fill(daset, "UyeEkleTable");
            dataGridView1.DataSource = daset.Tables["UyeEkleTable"];
            baglanti.Close();

            

        }


        private void UyeListelemeFrm_Load(object sender, EventArgs e)
        {
            uyelistele();
        }
    }
}
