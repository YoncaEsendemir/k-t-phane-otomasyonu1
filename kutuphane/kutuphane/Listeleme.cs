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

namespace kutuphane
{
    public partial class Listeleme : Form
    {
        static SqlDataAdapter da;
        static SqlConnection con;

        string cins;
        public Listeleme()
        {
            InitializeComponent();
        }
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();


        public static TabControl staticTabControl;
        public static TabPage staticTabPage;


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

        private void Listeleme_Load(object sender, EventArgs e)
        {
            
            staticTabControl = tabCotlListele;
            staticTabPage = tpKitapListele;

            UyeIslemleriClass2 Uye2class = new UyeIslemleriClass2();

            Uye2class.UyeListele(dgvUyeList);

            KitapClass kc = new KitapClass();
            kc.KitapListele(dgvKitaplistele);

            //con =new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DonemProje;Integrated Security=True");
            //string li = "Select *from TbLUyeIslemleri ";
            //con.Open();
            //da = new SqlDataAdapter(li, con);
            //DataTable dt = new DataTable(); 
            //da.Fill(dt);
            //dgvUyeList.DataSource = dt;
            //con.Close();
            

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            if (rdbtnErkek.Checked == true)
            {
                cins = rdbtnErkek.Text;
            }
            else if (rdbtnkadin.Checked == true)
            {
                cins = rdbtnkadin.Text;
            }

            if (tbxSifre.Text != tbxSifreTekrar.Text)
            {
                tbxSifre.Text = "";
                tbxSifreTekrar.Text = "";
                MessageBox.Show("iki şifre farklı tekrar deneyiniz","Uyarı");
            }

            UyeIslemleriClass2 uyeIslemleriClass2 = new UyeIslemleriClass2();


            UyeIslemleriClasscs uyeIslemleriClasscs = new UyeIslemleriClasscs()

            {   uyeid=Convert.ToInt32( dgvUyeList.CurrentRow.Cells[0].Value),
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

            uyeIslemleriClass2.guncelle(uyeIslemleriClasscs);

            UyeIslemleriClass2 Uye2class = new UyeIslemleriClass2();
            Uye2class.UyeListele(dgvUyeList);


            foreach(Control item in tpUyeListeleme.Controls) {
                if (item is TextBox)
                {
                    item.Text = "";
                    richTbxAdres.Text = "";
                }

            }
        }



        private void btnSil_Click(object sender, EventArgs e)
        {
            
        
            UyeIslemleriClass2 uyeIslemleriClass2= new UyeIslemleriClass2();
            uyeIslemleriClass2.sil( int.Parse(dgvUyeList.CurrentRow.Cells["uyeid"].Value.ToString()));
            MessageBox.Show("Uye başarili bir şekilde silindi");
            uyeIslemleriClass2.UyeListele(dgvUyeList);


        }

        private void dgvUyeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxTcNo.Text = dgvUyeList.CurrentRow.Cells[1].Value.ToString();
            tbxAdi.Text = dgvUyeList.CurrentRow.Cells[2].Value.ToString();
            tbxSoyad.Text = dgvUyeList.CurrentRow.Cells[3].Value.ToString();
            tbxYas.Text = dgvUyeList.CurrentRow.Cells[4].Value.ToString();
            cins = dgvUyeList.CurrentRow.Cells[5].Value.ToString();
            tbxEmail.Text = dgvUyeList.CurrentRow.Cells[6].Value.ToString();
            tbxSifre.Text = dgvUyeList.CurrentRow.Cells[7].Value.ToString();
            tbxSifreTekrar.Text = dgvUyeList.CurrentRow.Cells[8].Value.ToString();
            tbxTel.Text = dgvUyeList.CurrentRow.Cells[9].Value.ToString();
            richTbxAdres.Text = dgvUyeList.CurrentRow.Cells[10].Value.ToString();
            tbxil.Text = dgvUyeList.CurrentRow.Cells[11].Value.ToString();
            tbxilce.Text = dgvUyeList.CurrentRow.Cells[12].Value.ToString();

        }

      
        private void btnCik_Click(object sender, EventArgs e)
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

        private void btncik2_Click(object sender, EventArgs e)
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


        private void tbxAra_TextChanged(object sender, EventArgs e)
        {
            KitapClass kitapClass = new KitapClass();
            string kelimeAra;
            kelimeAra = tbxAra.Text;
            if (!String.IsNullOrEmpty(kelimeAra))
            {
                kitapClass.KitapAra(dgvKitaplistele, kelimeAra);
            }
           //else if (!String.IsNullOrEmpty(kelimeAra))
           // {
           //     kitapClass.KitapAra(dgvKitaplistele, kelimeAra);
           //     if (dgvKitaplistele.Rows[0].Cells[0].Value.ToString()==" ")
           //     {
           //         MessageBox.Show("Bulunamadı!");
           //     }
          //}
            else if (String.IsNullOrEmpty(kelimeAra))
            {
                kitapClass.KitapListele(dgvKitaplistele);
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

        private void tbxTel_TextChanged(object sender, EventArgs e)
        {
            tbxTel.Text=tbx(tbxTel.Text);
        }

        private void tbxTcNo_TextChanged(object sender, EventArgs e)
        {
           tbxTcNo.Text=tbx(tbxTcNo.Text);
        }

        private void tbxYas_TextChanged(object sender, EventArgs e)
        {
            tbxYas.Text=tbx(tbxYas.Text);
        }
    }
    }

