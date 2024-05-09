using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices.WindowsRuntime;

namespace kutuphane
{
    public partial class UyeIslemleri : Form
    {

        string cins = "";
        public UyeIslemleri()
        {
            InitializeComponent();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

       


        //public bool onlyEmail( string eMail)
        // {
        //     bool Result = false;
        //     try{
        //         var eMailValidator = new System.Net.Mail.MailAddress(eMail);
        //         Result = (eMail.LastIndexOf(".") > eMail.LastIndexOf("@"));
        //     }
        //     catch (SmtpException exp)

        //     {
        //         MessageBox.Show("geçerli e-mail girilmemiştir "+exp.Message);

        //     }

        //     return Result;
        // } 


    

        string tbx(string s)
        {
            foreach (char chr in s)
            {
                if (!Char.IsNumber(chr))
                {
                    MessageBox.Show("lütfen rakam giriniz!");
                    s = "";
                    return s;
                }
            }
            return s;
        }

        public void btnOlus()
        {
            Button btnExit = new Button();
            btnExit.Left = 314;
            btnExit.Top = 0;
            btnExit.Name = "cik";
            btnExit.Text = "X";
            //btnExit.Font= Font;
            btnExit.ForeColor = Color.Black;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Size = new Size(30, 30);
            btnExit.TabIndex = 19;
            btnExit.ImageIndex = (5);
            btnExit.BackColor = Color.FromArgb(64, 64, 64);
            btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //tpUyeEkle.Controls.Add(btnExit);
            //tabControl1.SelectedTab = tpUyeEkle;

            btnExit.Click += new EventHandler(button_Click);


            void button_Click(object sender, EventArgs e)
            {
                {
                    DialogResult dr = MessageBox.Show("Cikmak istediğine emin misiniz", "Cikiş", MessageBoxButtons.YesNo);
                    if (dr == DialogResult.Yes)
                    {
                        Close();
                    }
                    else
                    {

                    }
                }
            }

            p1.Controls.Add(btnExit);

        }


        public void picturOlus()
        {
            pcbxt.ImageLocation = @"C:\Users\Yonca\Downloads\icons8-library-64.png";
            pcbxt.SizeMode = PictureBoxSizeMode.StretchImage;
            pcrBox2.ImageLocation = @"C:\Users\Yonca\Downloads\icons8-library-64.png";
            pcrBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        void GeriAlma()
        {
            tabControl1.SelectedTab = tpUyeEkle;

        }

        public static TabControl staticTapControl;
        public static TabPage staticKitapArama;


        private void UyeIslemleri_Load(object sender, EventArgs e)
        {
            staticTapControl = tabControl1;
            staticKitapArama = tpKitapEklArama;

            btnOlus();
            picturOlus();

            

        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Cikmak istediğine emin misiniz", "Cikiş", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Close();
            }
            else
            {

            }
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (tbxEmail.Text.Contains("@"))
            //    {
            //        if (tbxEmail.Text.EndsWith(".com"))
            //        {
            //            MessageBox.Show("d");
            //        }
            //        else
            //        {
            //            MessageBox.Show("geçerli değil");
            //        }
            //    }
            //    else
            //    {
            //        MessageBox.Show("geçerli değil");
            //    }

            //}
            //catch {
            //    btnKayit.Enabled = false;
            //    MessageBox.Show("geçerli değil!!!");

            //}

            //if (rdbtnkadin.Checked == false)
            //{
            //    MessageBox.Show("uyelik koşularını kabul etmediziz ");
            //    return;
            //}

            //if (tbxSifre.Text != tbxSifreTekrar.Text)
            //{
            //    MessageBox.Show("iki şifre farklı tekrar deneyiniz");
            //}

            tbxEmail.Text = tbxEmail.Text + "@gmail.com";

            if (rdbtnErkek.Checked == true)
            {
                cins = rdbtnErkek.Text;
            }
            else if (rdbtnkadin.Checked == true)
            {
                cins = rdbtnkadin.Text;
            }
            UyeIslemleriClass2 uyeIslemleriClass2 = new UyeIslemleriClass2();


            UyeIslemleriClasscs uyeIslemleriClasscs = new UyeIslemleriClasscs()

            {

                tc = tbxTcNo.Text,
                ad = tbxAdi.Text,
                soyad = tbxSoyad.Text,
                yas = Convert.ToInt32(tbxYas.Text),
                cinsiyet = cins,
                mail = tbxEmail.Text,
                sifre = tbxSifre.Text,
                sifretekrar = tbxSifreTekrar.Text,
                tel = tbxTel.Text,
                adres = richTbxAdres.Text,
                il = tbxil.Text,
                ilce = tbxilce.Text,
            };

            uyeIslemleriClass2.Ekle(uyeIslemleriClasscs);

            foreach (Control item in p2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                    richTbxAdres.Text = "";

                }

            }
        }




        private void tbxTcNo_TextChanged(object sender, EventArgs e)
        {
            string s1 = tbxTcNo.Text;
            tbxTcNo.Text = tbx(s1);

        }

        private void tbxYas_TextChanged(object sender, EventArgs e)
        {
           
            tbxYas.Text = tbx(tbxYas.Text);
        }

        private void tbxTel_TextChanged(object sender, EventArgs e)
        {
            string y = tbxTel.Text;
               y=tbx(tbxTel.Text);
            tbxTel.Text = "0  "+y;

        }

        private void BynEkle_Click(object sender, EventArgs e)
        {
            KitapClass2 kpCs = new KitapClass2()
            {
                KitapTuruId = Convert.ToInt32(tbxKitapTuruNo.Text),
                StokSayisi = Convert.ToInt32(tbxStokSayi.Text),
                BarKodno = tbxBarkod.Text,
                KitapAdi = tbxKitapAd.Text,
                yazar = tbxYazar.Text,
                yayinevi = tbxYayinevi.Text,
                KitapTuru = cbxKitapTuru.SelectedItem.ToString(),
                SayfaSayisi = Convert.ToInt32(tbxSayfa.Text),
                RafNo = tbxRafNo.Text,
                Aciklama = rtbxAciklama.Text,
                KayitTarih = Convert.ToDateTime(dtpKayitTarih.Value),

            };

            KitapClass kitapClass = new KitapClass();
            kitapClass.KitapEkle(kpCs);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            foreach (Control item in p4.Controls) {
                if (item is TextBox)
                {
                    item.Text = "";
                    cbxKitapTuru.Text = "";
                    rtbxAciklama.Text = "";
                }

            }

        }

        private void btncik_Click(object sender, EventArgs e)
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

        private void p3_MouseDown(object sender, MouseEventArgs e)
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

        private void p1_MouseDown(object sender, MouseEventArgs e)
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

        private void tbxStokSayi_TextChanged(object sender, EventArgs e)
        {
            tbxStokSayi.Text = tbx(tbxStokSayi.Text);
        }

        private void tbxSayfa_TextChanged(object sender, EventArgs e)
        {
            tbxSayfa.Text = tbx(tbxSayfa.Text);
        }

        private void cbxKitapTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxKitapTuru.SelectedIndex == 0)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "1";
            }

            else if (cbxKitapTuru.SelectedIndex == 1)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "2";
            }

            else if (cbxKitapTuru.SelectedIndex == 2)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "3";
            }
            else if (cbxKitapTuru.SelectedIndex == 3)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "4";
            }
            else if (cbxKitapTuru.SelectedIndex == 4)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "5";
            }

            else if (cbxKitapTuru.SelectedIndex == 5)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "6";
            }
            else if (cbxKitapTuru.SelectedIndex == 6)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "7";
            }
            else if (cbxKitapTuru.SelectedIndex == 7)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "8";
            }
            else if (cbxKitapTuru.SelectedIndex == 8)
            {
                tbxKitapTuruNo.Text = "";
                tbxKitapTuruNo.Text = "9";
            }

        }

        //public bool IsValidEmail(string addy)
        //{
        //    try
        //    {
        //        MailAddress test = new MailAddress(addy);
        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
         
            //if (tbxEmail.Text.Contains("@"))
            //{
            //    if (tbxEmail.Text.EndsWith(".com"))
            //    {
            //        MessageBox.Show("d");
            //    }
            //    else
            //    {
            //        MessageBox.Show("geçerli değil");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("geçerli değil");
            //}
        }

        private void tbxSifreTekrar_TextChanged(object sender, EventArgs e)
        {
            if (tbxSifre.Text!=tbxSifreTekrar.Text)
            {
                MessageBox.Show("gh");
            }


        }

       













        //foreach (Control item in Controls) if (item is TextBox) item.Text = "";



    }
}
                             