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
    public partial class AnaSayfaFrm : Form
    {
        public AnaSayfaFrm()
        {
            InitializeComponent();
        }
        
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = KütüphaneOtomasyon; Integrated Security = True");
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void AnaSayfaFrm_Load(object sender, EventArgs e)
        {

        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            UyeEkleFrm uyeekle = new UyeEkleFrm();
            uyeekle.ShowDialog();
        }

        private void btnUyeListele_Click(object sender, EventArgs e)
        {
            UyeListelemeFrm uyelistele = new UyeListelemeFrm();
            uyelistele.ShowDialog();

        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            KitapEkleFrm kitapekle = new KitapEkleFrm();
            kitapekle.ShowDialog();
        }

        private void btnKitapListele_Click(object sender, EventArgs e)
        {
            KitapListeleFrm kitaplistele = new KitapListeleFrm();
            kitaplistele.ShowDialog();
        }

        private void btnEmanetKitapVerme_Click(object sender, EventArgs e)
        {
            EmanetKitapVerFrm emanetkitap = new EmanetKitapVerFrm();
            emanetkitap.ShowDialog();
        }

        private void btnEmanetKitapListele_Click(object sender, EventArgs e)
        {
            EmanetKitapListelefrm emanetkitaplistele = new EmanetKitapListelefrm();
            emanetkitaplistele.ShowDialog();
        }

        private void btnEmanetKitapIade_Click(object sender, EventArgs e)
        {
            EmanetKitapİadefrm iade = new EmanetKitapİadefrm();
            iade.ShowDialog();
        }

        private void btnSırala_Click(object sender, EventArgs e)
        {
            Sıralamafrm sırala = new Sıralamafrm();
            sırala.ShowDialog();

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Grafikfrm grafik = new Grafikfrm();
            grafik.ShowDialog();
        }
    }
}
