using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class frm1 : Form
    {
        public frm1()
        {
            InitializeComponent();
            UyeIslemleriClass2.BaglantiDogrulama();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void Form1_Load(object sender, EventArgs e)
        {   
            //Thread.Sleep(1000);
            MessageBox.Show("Yapmak istedığınız işlemi Seçiniz");
        }

        private void btnUyeEkleme_Click(object sender, EventArgs e)
        {
            UyeIslemleri uye = new UyeIslemleri();
            uye.Show();
           

        }

        private void btnUyeGunceleme_Click(object sender, EventArgs e)
        {

            UyeIslemleri uye = new UyeIslemleri();
            uye.Show();

        }

        private void btnUyeListele_Click(object sender, EventArgs e)
        {
            Listeleme lisrFrm = new Listeleme();
            lisrFrm.Show();
            
        }

        private void btnKitapListele_Click(object sender, EventArgs e)
        {
            Listeleme page = new Listeleme();
            page.Show();
            Listeleme.staticTabControl.SelectedTab= Listeleme.staticTabPage;
        }

        private void btnKitapEkleAra_Click(object sender, EventArgs e)
        {
            UyeIslemleri uye = new UyeIslemleri();
            uye.Show();
            UyeIslemleri.staticTapControl.SelectedTab = UyeIslemleri.staticKitapArama;

        }

        private void btnEmanetKitapVerme_Click(object sender, EventArgs e)
        {
            Login login= new Login();
            login.Show();

        }

        private void btnEmanetKitapiade_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();

        }

        private void btnCik_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Cıkmak istediğinize emin misiniz", "uyarı", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
            {

            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks == 1 && e.Y <= this.Height && e.Y >= 0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            }
        }

        private void btnEmanetKitaplariListele_Click(object sender, EventArgs e)
        {
            EmanetKitapListele emkl= new EmanetKitapListele();
            emkl.Show();
        }

      
    }
}
