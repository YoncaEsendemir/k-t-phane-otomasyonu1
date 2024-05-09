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
    public partial class EmanetKitapListele : Form
    {
        public EmanetKitapListele()
        {
            InitializeComponent();
        }

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ReleaseCapture();


        public static SqlDataAdapter da;
        public static SqlDataReader dr;
        public static SqlCommand com;

        DataSet ds= new DataSet();
       SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DonemProje;Integrated Security=True");

        public void listele()
        {
            con.Open();
            da= new SqlDataAdapter("Select *from TBLEmanetKitap",con);
            da.Fill(ds, "TBLEmanetKitap");
            dgvEmanetKitaplar.DataSource = ds.Tables["TBLEmanetKitap"];
            con.Close();
        }


        private void EmanetKitapListele_Load(object sender, EventArgs e)
        {
            listele();
            cbxFiltrele.SelectedIndex = 0;
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

        private void cbxFiltrele_SelectedIndexChanged(object sender, EventArgs e)
        {
            ds.Tables["TBLEmanetKitap"].Clear();
            if(cbxFiltrele.SelectedIndex==0)
            {
                listele();
            }
            else if (cbxFiltrele.SelectedIndex == 1)
            {
                con.Open();
                da = new SqlDataAdapter("Select *from TBLEmanetKitap where'"+ DateTime.Now.ToShortDateString()+"'>IadeTarih", con);
                da.Fill(ds, "TBLEmanetKitap");
                dgvEmanetKitaplar.DataSource = ds.Tables["TBLEmanetKitap"];
                con.Close();

            }
            else if(cbxFiltrele.SelectedIndex == 2)
            {

                con.Open();
                da = new SqlDataAdapter("Select *from TBLEmanetKitap where'" + DateTime.Now.ToShortDateString() + "'<=IadeTarih", con);
                da.Fill(ds, "TBLEmanetKitap");
                dgvEmanetKitaplar.DataSource = ds.Tables["TBLEmanetKitap"];
                con.Close();
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

        private void tbxIadeUyeIdAra_TextChanged(object sender, EventArgs e)
        {
            ds.Tables["TBLEmanetKitap"].Clear();
            con.Open();
            da = new SqlDataAdapter("select *from TBLEmanetKitap where UyeID like'%" + Convert.ToInt32(tbxIadeUyeIdAra.Text) + "%'", con);
            da.Fill(ds, "TBLEmanetKitap");

            con.Close();
            if (tbxIadeUyeIdAra.Text == "")
            {
                ds.Tables["TBLEmanetKitap"].Clear();
                listele();
            }
        }

        private void tbxIadeKitapIdAra_TextChanged(object sender, EventArgs e)
        {
            if (tbxIadeKitapIdAra.Text != "") {
                ds.Tables["TBLEmanetKitap"].Clear();
                con.Open();
                da = new SqlDataAdapter("select *from TBLEmanetKitap where KitapID like'%" + Convert.ToInt32(tbxIadeKitapIdAra.Text) + "%'", con);
                da.Fill(ds, "TBLEmanetKitap");
                con.Close();
            }
            else if (tbxIadeKitapIdAra.Text == "")
            {
                ds.Tables["TBLEmanetKitap"].Clear();
                listele();
            }
        }

        private void btnTeslimAl_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("delete from TBLEmanetKitap where UyeID=@UyeID and KitapID=@KitapID", con);
            com.Parameters.AddWithValue("@UyeID", int.Parse(dgvEmanetKitaplar.CurrentRow.Cells["UyeID"].Value.ToString()));
            com.Parameters.AddWithValue("@KitapID", int.Parse(dgvEmanetKitaplar.CurrentRow.Cells["KitapID"].Value.ToString()));
            com.ExecuteNonQuery();
            SqlCommand com2 = new SqlCommand("update TBLKitapBilgi set StokSayisi=StokSayisi + '" + int.Parse(dgvEmanetKitaplar.CurrentRow.Cells["KitapSayisi"].Value.ToString()) + "' where KitapId=@KitapId", con);
            com2.Parameters.AddWithValue("@KitapID", int.Parse(dgvEmanetKitaplar.CurrentRow.Cells["KitapID"].Value.ToString()));
            con.Close();
            MessageBox.Show("y");
            ds.Tables["TBLEmanetKitap"].Clear();
            listele();
        }
    }
}
