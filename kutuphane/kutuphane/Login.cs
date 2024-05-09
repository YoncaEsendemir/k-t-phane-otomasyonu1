using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        //public class LoginUye
        //{
        //    public string sifre;
        //    public string  sifretekrar
        //        public string mail
        //}
        private void linklblUyeOL_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UyeIslemleri uyeIslemleri= new UyeIslemleri();
            uyeIslemleri.Show();
            this.Close();
        }



        private void tbxlogin_TextChanged(object sender, EventArgs e)
        {
            //if(tbxlogin==)

        }


        private void btnCik_Click(object sender, EventArgs e)
        {
            DialogResult dr= MessageBox.Show("Cikmak istediğine emin misin", "Cik", MessageBoxButtons.YesNo);

            if (dr==DialogResult.Yes)
            {
                Close();
            }
            else
            {

            }

        }
       
        private void btnGiris_Click(object sender, EventArgs e)
        {
            if (tbxlogin.Text == string.Empty)
            {
                lblKulanici.Visible = true;
            }

            if (tbxSifre.Text == string.Empty)
            {
                lblSifre.Visible = true;
            }

            if (tbxSifre.Text == string.Empty)
            {
                lblSifreTekrar.Visible = true;
            }
            //if (tbxSifre.Text == string.Empty || tbxSifre.Text == string.Empty || tbxlogin.Text == string.Empty)
            //{

            //}
            UyeIslemleriClass2 uy2 = new UyeIslemleriClass2();

            LoginIslemleri lgnim = new LoginIslemleri() {
                ad = tbxlogin.Text,
                sifre = tbxSifre.Text,
                sifretekrar = tbxSifreTekrar.Text,
            };

            uy2.loginIslemi(lgnim);

            this.Close();


        }

        private void panel7_MouseDown(object sender, MouseEventArgs e)
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

        private void linklblSifre_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
            SifreUnttum sifreUnttum= new SifreUnttum();
            sifreUnttum.Show();
            Login login = new Login();
            this.Close();


        }
    }
}
