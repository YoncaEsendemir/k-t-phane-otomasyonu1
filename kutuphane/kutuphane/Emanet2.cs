using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;

namespace kutuphane
{
    internal class Emanet2
    {
        SqlCommand com;
        SqlCommand com2;
        SqlDataAdapter da;
        SqlDataReader dr;
        DataTable dt = new DataTable();

        SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DonemProje;Integrated Security=True");


        //public void KitapSayisi(Sepet s)
        //{
            
        //    con.Open();
        //    com2 = new SqlCommand("select sum(KitapSayisi) from TBLSepet",con);
        //    s.KitapSayisi = Convert.ToInt32(com2.ExecuteScalar());
        //    con.Close();
        //}

        public void SepetEkle(Sepet spt)
        {
            DataTable dt = new DataTable();
             dt.Clear();
            con.Open();
            string komut = "insert into TBLSepet(KitapId,BarKodno,KitapAdi,Yazar,Yayinevi,SayfaSayisi,KitapSayisi,TeslimTarih,IadeTarih) values (@KitapId,@BarKodno,@KitapAdi,@Yazar,@Yayinevi,@SayfaSayisi,@KitapSayisi,@TeslimTarih,@IadeTarih)";
            com= new SqlCommand(komut,con);
            com.Parameters.AddWithValue("@KitapId",spt.KitapId);
            com.Parameters.AddWithValue("@BarKodno", spt.BarKodno);
            com.Parameters.AddWithValue("@KitapAdi",spt.KitapAdi);
            com.Parameters.AddWithValue("@Yazar",spt.Yazar);
            com.Parameters.AddWithValue("@Yayinevi",spt.Yayinevi);
            com.Parameters.AddWithValue("@SayfaSayisi",spt.SayfaSayisi);
            com.Parameters.AddWithValue("@KitapSayisi",spt.KitapSayisi);
            com.Parameters.AddWithValue("@TeslimTarih",spt.TeslimTarih);
            com.Parameters.AddWithValue("@IadeTarih",spt.IadeTarih);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sepete Eklendi");

        }

       public DataGridView SepetListe(DataGridView dgvSepet)
        {
            con.Open();
            string komut = "select  *from TBLSepet ";
            da = new SqlDataAdapter(komut,con);
            DataTable dt= new DataTable();
            da.Fill(dt); 
            dgvSepet.DataSource = dt;
            con.Close();
            return dgvSepet;
        }

        public void UyeAra(string Uyeid, UyeIslemleriClasscs u,Emanet ema)
        {
            con.Open() ;
            com = new SqlCommand("select *from TBLUyeIslemleri where uyeid like '%"+ Uyeid+"%'",con);
            dr=com.ExecuteReader();
            while(dr.Read()) // okuduğu sürece bunu yapsın!!
            {
                u.ad = dr["ad"].ToString();
                u.yas = Convert.ToInt32(dr["yas"]);
                u.tel = dr["tel"].ToString();
            }
            con.Close();

            //con.Open();
            //com2 = new SqlCommand("select sum(KitapSayisi) from TBLEmanetKitap",con);
            //ema.KitapSayisi = Convert.ToInt32(com2.ExecuteScalar());
            //con.Close();

            
        }

        public void KitapBul(int kitapAra, KitapClass2 k2)
        {
            con.Open();
            com = new SqlCommand("select *from TBLKitapBilgi where KitapId like '%"+ kitapAra + "%'",con);
            dr = com.ExecuteReader();// list die objekte und und last sie laufen danach geht wird es zu dr zugeordnet 
            while (dr.Read()) // okuduğu sürece bunu yapsın!!
            {
                k2.KitapAdi = dr["KitapAdi"].ToString();
                k2.yazar = dr["yazar"].ToString();
                k2.BarKodno = dr["BarKodno"].ToString() ;
                k2.yayinevi = dr["yayinevi"].ToString();
                k2.SayfaSayisi = Convert.ToInt32(dr["SayfaSayisi"]);
            }
            con.Close();
        }


        public void Sil(string a)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            con.Open();
            com = new SqlCommand("Delete from TBLSepet where KitapId ='" +a+"' ", con);
            com.ExecuteNonQuery();
            con.Close();
        }

        //public void IadeUyeBUl(string a,Emanet em)
        //{
        //        con.Open();
        //        dt.Clear();
        //        con.Open();
        //        da = new SqlDataAdapter("select * from TBLEmanetKitap where UyeID like '%" + a + "%'", con);
        //        da.Fill(dt);

        //}



    }
}
