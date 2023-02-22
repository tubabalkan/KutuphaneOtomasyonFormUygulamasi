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
    public partial class Sıralamafrm : Form
    {
        public Sıralamafrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");
        DataSet daset = new DataSet();
        private void Sıralamafrm_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from UyeEkleTable order by okukitapsayısı desc", baglanti);
            adtr.Fill(daset, "UyeEkleTable");
            dataGridView1.DataSource = daset.Tables["UyeEkleTable"];
            baglanti.Close();
            lblEnCok.Text = "";
            lblEnAz.Text = "";
            lblEnCok.Text = daset.Tables["UyeEkleTable"].Rows[0]["adsoyad"].ToString()+"=";
            lblEnCok.Text += daset.Tables["UyeEkleTable"].Rows[0]["okukitapsayısı"].ToString();
            lblEnAz.Text = daset.Tables["UyeEkleTable"].Rows[dataGridView1.Rows.Count-2]["adsoyad"].ToString()+"=";
            lblEnAz.Text += daset.Tables["UyeEkleTable"].Rows[dataGridView1.Rows.Count - 2]["okukitapsayısı"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
