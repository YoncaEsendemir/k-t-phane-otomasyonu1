using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace kutuphane
{
    public partial class EmanetIade : Form
    {
        public EmanetIade()
        {
            InitializeComponent();
        }
   
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam,int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        SqlCommand com;
        SqlDataAdapter da;

        DataSet ds = new DataSet();
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DonemProje;Integrated Security=True");
      


        public void KitapSayisi()
        {

            con.Open();
            com= new SqlCommand("select sum(KitapSayisi) from TBLSepet", con);
            lblKitapsayisi.Text =com.ExecuteScalar().ToString();
            con.Close();
        }

        private void EmanetIade_Load(object sender, EventArgs e)
        {
            Emanet2 em2 = new Emanet2();
            em2.SepetListe(dgvEmanet);

        
      
            //Login login = new Login();
            //login.Close();
        }

    

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Sepet spt = new Sepet()
            {
                KitapId = Convert.ToInt32(tbxKitapId.Text),
                BarKodno= tbxBarkodno.Text,
                KitapAdi = tbxKitapAd.Text,
                Yazar = tbxYazar.Text,
                Yayinevi = tbxYayinevi.Text,
                SayfaSayisi = Convert.ToInt32(tbxSayfaSayisi.Text),
                KitapSayisi = Convert.ToInt32(tbxKitapSayisi.Text),
                TeslimTarih = dtpTeslim.Value,
                IadeTarih = dtpIade.Value,
            };
            Emanet2 em2 = new Emanet2();
            em2.SepetEkle(spt);
            em2.SepetListe(dgvEmanet);
            lblKitapsayisi.Text = "";
            KitapSayisi();
            foreach (Control item in gbxKitap.Controls)
            {
                if (item is TextBox)
                {
                    if (item!=tbxKitapSayisi)
                    {
                        item.Text = "";
                    }

                }
            }

           

            //em2.KitapSayisi(spt);
            //lblKitapsayisi.Text = "";
            //lblKitapsayisi.Text=spt.KitapSayisi.ToString();
            
        }

        private void EmanetKitaplar_Click(object sender, EventArgs e)
        {
            //Emanet2 em2 = new Emanet2();
            //em2.SepetListe(dgvEmanet);
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

        private void tbxIdAra_TextChanged(object sender, EventArgs e)
        {
                
            UyeIslemleriClasscs uic = new UyeIslemleriClasscs();
            Emanet em = new Emanet();
            Emanet2 em2 = new Emanet2();
            em2.UyeAra(tbxIdAra.Text,uic,em);
            tbxAd.Text = uic.ad;
            tbxYas.Text = uic.yas.ToString();
            tbxTel.Text= uic.tel;

           con.Open();
            SqlCommand com2 = new SqlCommand("select sum(KitapSayisi) from TBLEmanetKitap", con);
            lblKayitliKitap.Text=com2.ExecuteScalar().ToString();
            con.Close();

            if (tbxIdAra.Text == "")
            {
                foreach (Control item in gbxUye.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                        lblKayitliKitap.Text = "";
                    }
                   
                }

            }
            else
            {
                lblKayitliKitap.Text = "";
            }
        }

        private void tbxKitapId_TextChanged(object sender, EventArgs e)
        {
            if (tbxKitapId.Text!="")
            {
                int a = Convert.ToInt32(tbxKitapId.Text);

                KitapClass2 kp2 = new KitapClass2();

                Emanet2 em2 = new Emanet2();
                em2.KitapBul(a, kp2);
                tbxKitapAd.Text = kp2.KitapAdi;
                tbxBarkodno.Text = kp2.BarKodno;
                tbxYazar.Text = kp2.yazar;
                tbxYayinevi.Text = kp2.yayinevi;
                tbxSayfaSayisi.Text = kp2.SayfaSayisi.ToString();
    
            }

            else
            {
                MessageBox.Show("Almak istediğiniz kitap Id giriniz");
            }

            if (tbxKitapId.Text=="")
            {
                foreach (Control item in gbxKitap.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item !=tbxKitapSayisi)
                        {
                            item.Text = "";
                            lblKayitliKitap.Text = "";
                        }
                    }

                } }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Emanet2 em2 = new Emanet2();
            em2.Sil(dgvEmanet.CurrentRow.Cells["KitapId"].Value.ToString());
            MessageBox.Show("Silme işlemi yapıldı","Silme işlemi");
            em2.SepetListe(dgvEmanet);
            lblKitapsayisi.Text = "";
            //lblKayitliKitap.Text="";
            KitapSayisi();

            //Sepet spt = new Sepet();
            //lblKitapsayisi.Text = "";
            //em2.KitapSayisi(spt);
            //lblKitapsayisi.Text = spt.KitapSayisi.ToString();


        }
        private void btnTeslim_Click(object sender, EventArgs e)
        {
            try
            {
                if (lblKitapsayisi.Text!="") 
                {
                    //lblKayitliKitap.Text=="" && Convert.ToInt32(lblKitapsayisi.Text)<=4 || lblKayitliKitap.Text!="" && (Convert.ToInt32(lblKitapsayisi.Text) + Convert.ToInt32(lblKayitliKitap))<= 4


                    if (lblKayitliKitap.Text.Trim().Length <= 0 && Convert.ToInt32(lblKitapsayisi.Text) <= 4 || lblKayitliKitap.Text.Trim().Length > 0 && (Convert.ToInt32(lblKitapsayisi.Text) + Convert.ToInt32(lblKayitliKitap.Text)) <= 4)
                    {
                        if (tbxIdAra.Text != "" && tbxAd.Text != "" && tbxYas.Text!= ""&& tbxTel.Text!="")
                        {
                            for (int i = 0; i < dgvEmanet.Rows.Count - 1; i++)
                            {
                                con.Open();
                                SqlCommand com = new SqlCommand("insert into TBLEmanetKitap(UyeID,Ad,Yas,Telefon,KitapID,BarKodno,Kitapadi,Yazar,Yayinevi,SayfaSayisi,KitapSayisi,TeslimTarih,IadeTarih) values (@UyeID,@Ad,@Yas,@Telefon,@KitapID,@BarKodno,@Kitapadi,@Yazar,@Yayinevi,@SayfaSayisi,@KitapSayisi,@TeslimTarih,@IadeTarih)", con);
                                com.Parameters.AddWithValue("@UyeID", Convert.ToInt32(tbxIdAra.Text));
                                com.Parameters.AddWithValue("@Ad",tbxAd.Text);
                                com.Parameters.AddWithValue("@Yas",Convert.ToInt32(tbxYas.Text));
                                com.Parameters.AddWithValue("@Telefon",tbxTel.Text);
                                com.Parameters.AddWithValue("KitapID",Convert.ToInt32(dgvEmanet.Rows[i].Cells["KitapId"].Value.ToString()));
                                com.Parameters.AddWithValue("BarKodno", dgvEmanet.Rows[i].Cells["BarKodno"].Value.ToString());
                                com.Parameters.AddWithValue("Kitapadi", dgvEmanet.Rows[i].Cells["Kitapadi"].Value.ToString());
                                com.Parameters.AddWithValue("Yazar", dgvEmanet.Rows[i].Cells["Yazar"].Value.ToString());
                                com.Parameters.AddWithValue("Yayinevi", dgvEmanet.Rows[i].Cells["Yayinevi"].Value.ToString());
                                com.Parameters.AddWithValue("SayfaSayisi",Convert.ToInt32(dgvEmanet.Rows[i].Cells["SayfaSayisi"].Value.ToString()));
                                com.Parameters.AddWithValue("KitapSayisi",Convert.ToInt32(dgvEmanet.Rows[i].Cells["KitapSayisi"].Value.ToString()));
                                com.Parameters.AddWithValue("TeslimTarih",Convert.ToDateTime(dgvEmanet.Rows[i].Cells["TeslimTarih"].Value.ToString()));
                                com.Parameters.AddWithValue("IadeTarih",Convert.ToDateTime(dgvEmanet.Rows[i].Cells["IadeTarih"].Value.ToString()));
                                com.ExecuteNonQuery();

                                SqlCommand com2 = new SqlCommand("Update TBLKitapBilgi set StokSayisi=StokSayisi - '"+Convert.ToInt32(dgvEmanet.Rows[i].Cells["KitapSayisi"].Value.ToString()) + "' where KitapId='"+int.Parse(dgvEmanet.Rows[i].Cells["KitapId"].Value.ToString()) +"'",con);
                                com2.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Stoktan düştü");

                            }
                           
                            con.Open();
                            SqlCommand com3 = new SqlCommand("Delete from TBLSepet ", con);
                            com3.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("kitap-lar eklendıi", "Uyari");

                            DataTable dt = new DataTable();
                            dt.Clear();
                            Emanet2 em2 = new Emanet2();
                            em2.SepetListe(dgvEmanet);

                            tbxIdAra.Text = "";
                            lblKayitliKitap.Text = "";
                            lblKitapsayisi.Text = "";
                            KitapSayisi();
                        
                        }
                        else
                        {
                            MessageBox.Show("Önce üye ismi seçiniz  !!", "Uyarı");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Emanet Kitap sayisi 4 fazla olamaz !!","Uyarı");
                    }
                    }
                else
                {
                    MessageBox.Show("Sepet boş Kitap Eklemenız gerekir!!","Uyarı");
                }
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }

        }

        private void panel14_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                if (e.Clicks==1 && e.Y<=this.Height && e.Y>=0)
                {
                    ReleaseCapture();
                    SendMessage(this.Handle,WM_NCLBUTTONDOWN,HT_CAPTION,0);
                }
            }
        }

      

        private void btnCik2_Click(object sender, EventArgs e)
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

        private void IadeKitaplaraGit_Click(object sender, EventArgs e)
        {
           
            
            EmanetKitapListele eml2 = new EmanetKitapListele();
             eml2.Show();
            this.Close();

        }

 

        }
    }

