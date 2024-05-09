using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace kutuphane
{
    internal class KitapClass
    {
        public static DataTable dt;
        public static SqlDataAdapter da;
        public static SqlDataReader dr;
        public static SqlCommand com;
        public static SqlConnection con;

        string SqlCon= @"Data Source=.\SQLEXPRESS;Initial Catalog=DonemProje;Integrated Security=True";
        public void KitapEkle(KitapClass2 kpCs2)
        {
            using(con= new SqlConnection(SqlCon))
            {
                try
                {
                    string Command = "insert into TBLKitapBilgi( KitapTuruId,StokSayisi,BarKodNo,KitapAdi,yazar,yayinevi,KitapTuru,SayfaSayisi,RafNo,Aciklama,KayitTarih)" +
                        "values (@KitapTuruId,@StokSayisi,@BarKodNo,@KitapAdi,@yazar,@yayinevi,@KitapTuru,@SayfaSayisi,@RafNo,@Aciklama,@KayitTarih)";
                    con.Open();
                    com = new SqlCommand(Command,con);
                    com.Parameters.AddWithValue("@KitapTuruId",kpCs2.KitapTuruId) ;
                    com.Parameters.AddWithValue("@StokSayisi", kpCs2.StokSayisi);
                    com.Parameters.AddWithValue("@BarKodNo", kpCs2.BarKodno);
                    com.Parameters.AddWithValue("@KitapAdi", kpCs2.KitapAdi);
                    com.Parameters.AddWithValue("@yazar", kpCs2.yazar);
                    com.Parameters.AddWithValue("@yayinevi", kpCs2.yayinevi);
                    com.Parameters.AddWithValue("@KitapTuru", kpCs2.KitapTuru);
                    com.Parameters.AddWithValue("@SayfaSayisi", kpCs2.SayfaSayisi);
                    com.Parameters.AddWithValue("@RafNo", kpCs2.RafNo);
                    com.Parameters.AddWithValue("@Aciklama", kpCs2.Aciklama);
                    com.Parameters.AddWithValue("@KayitTarih", kpCs2.KayitTarih);
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kitap Başarili bir şekile eklendi!!!");

                }
                catch (SqlException se) 
                {
                    MessageBox.Show("İŞLEM HATALI"+se.Message);
                }
            }
        }

        public DataGridView KitapListele(DataGridView dgvKitap)
        {
            con = new SqlConnection(SqlCon);
            string list = "Select* from TBLKitapBilgi";
            con.Open();
            da=new SqlDataAdapter(list, con);
            dt = new DataTable();
            da.Fill(dt);
            dgvKitap.DataSource = dt;
            con.Close();
            return dgvKitap;
        }

        public DataGridView KitapAra(DataGridView dvgAra, string a)
        {
                con = new SqlConnection(SqlCon);
                dt.Clear();
                con.Open();
                da = new SqlDataAdapter("select * from TBlKitapBilgi where KitapAdi like '%" + a + "%'", con);
                da.Fill(dt);
                dvgAra.DataSource = dt;
                return dvgAra;
            }
        
    }
}
