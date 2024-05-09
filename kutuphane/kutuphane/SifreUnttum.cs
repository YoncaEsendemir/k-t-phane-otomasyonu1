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
    public partial class SifreUnttum : Form
    {
        public SifreUnttum()
        {
            InitializeComponent();
         
            //login.Visible = false;
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        private void btnSifreUnut_Click(object sender, EventArgs e)
        {
           
            UyeIslemleriClasscs uyics = new UyeIslemleriClasscs()
            {
                ad = tbxAd.Text,
                mail=tbxmail.Text,
            };

            UyeIslemleriClass2 uyics2 = new UyeIslemleriClass2();
              uyics2.SifreUnttum(uyics);
        }

        private void SifreUnttum_Load(object sender, EventArgs e)
        {
           
        }

        private void BtnCik_Click(object sender, EventArgs e)
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
    }
}
