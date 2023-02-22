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

namespace KütüphaneOtomasyon
{
    public partial class Grafikfrm : Form
    {
        public Grafikfrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");
        

        private void Grafikfrm_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select adsoyad,okukitapsayısı from UyeEkleTable", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                chart1.Series["Okunan Kitap Sayıısı"].Points.AddXY(read["adsoyad"].ToString(), read["okukitapsayısı"]);
            }
            baglanti.Close();
            chart1.Series["Okunan Kitap Sayıısı"].Color = Color.Orange;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
