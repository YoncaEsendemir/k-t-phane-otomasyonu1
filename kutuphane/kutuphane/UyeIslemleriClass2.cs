using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace kutuphane
{

    
   class UyeIslemleriClass2
    {
       public static DataTable dt;
       public static  SqlDataAdapter da;
       public static  SqlDataReader dr;
       public static SqlCommand com;
       public static  SqlConnection con;
        //SqlDataReader, sadece okunabilir olarak kullanılmaktadır.
        //Satır satır okuma işlemi yapılmaktadır. SqlDataReader kullanımı boyunca veritabanı 
        //bağlantısı açık olacaktır.Çünkü SqlDataReader veritabanı ile bağlantılı olarak çalışmaktadır.
        public static string SqlCon = @"Data Source=.\SQLEXPRESS;Initial Catalog=DonemProje;Integrated Security=True";
        //con = new SqlConnection(connection);

        public static bool BaglantiDogrulama() {
            using (con =new SqlConnection(SqlCon)) 
            { 
                try
                {
                    con.Open();
                    System.Windows.Forms.MessageBox.Show("bağlanti başarılı! ");
                    con.Close();
                    return true;
                }
                catch (SqlException exp)
                {
                    System.Windows.Forms.MessageBox.Show (exp.Message);
                    return false;
                }

            }
        }
              public void Ekle(UyeIslemleriClasscs uyeImcs)
             {
            try { 

             if (con.State==System.Data.ConnectionState.Closed)
                {
            //(tc,ad,soyad,yas,erkek,kadin,mail,sifre,sifretekrar,tel,adres,il,ilce)
            con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DonemProje;Integrated Security=True");
           con.Open ();
                    string kayit = "insert into  TBLUyeIslemleri(tc,ad,soyad,yas,cinsiyet,mail,sifre,sifretekrar,tel,adres,il,ilce) values(@tc,@ad,@soyad,@yas,@cinsiyet,@mail,@sifre,@sifretekrar,@tel,@adres,@il,@ilce)";
                    com = new SqlCommand(kayit, con);
                    com.Parameters.AddWithValue("@tc", uyeImcs.tc);
                    com.Parameters.AddWithValue("@ad", uyeImcs.ad);
                    com.Parameters.AddWithValue("@soyad", uyeImcs.soyad);
                    com.Parameters.AddWithValue("@yas", uyeImcs.yas);
                    com.Parameters.AddWithValue("@cinsiyet", uyeImcs.cinsiyet);
                    com.Parameters.AddWithValue("@mail", uyeImcs.mail);
                    com.Parameters.AddWithValue("@sifre", uyeImcs.sifre);
                    com.Parameters.AddWithValue("@sifretekrar", uyeImcs.sifretekrar);
                    com.Parameters.AddWithValue("@tel", uyeImcs.tel);
                    com.Parameters.AddWithValue("@adres", uyeImcs.adres);
                    com.Parameters.AddWithValue("@il", uyeImcs.il);
                    com.Parameters.AddWithValue("@ilce", uyeImcs.ilce);
                    com.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("kayidiniz gerçekleştı");
                }
            }

            catch(Exception hata)
            {
                MessageBox.Show("iŞLEM SIRASINDA HATA OLUŞTU"+ hata);
            }
          
        }

        public void guncelle( UyeIslemleriClasscs uyeImcs)
        {
            try
            {
                if ( con.State==System.Data.ConnectionState.Closed)
                {
                    con = new SqlConnection(SqlCon);
                    con.Open();
                    string kayit = "update TBLUyeIslemleri set tc=@tc,ad=@ad,soyad=@soyad,yas=@yas,cinsiyet=@cinsiyet," +
                    "mail=@mail,sifre=@sifre,sifretekrar=@sifretekrar,tel=@tel,adres=@adres,il=@il,ilce=@ilce where uyeid=@uyeid";

                    com = new SqlCommand(kayit, con);
                    com.Parameters.AddWithValue("@uyeid", uyeImcs.uyeid);
                    com.Parameters.AddWithValue("@tc", uyeImcs.tc);
                    com.Parameters.AddWithValue("@ad", uyeImcs.ad);
                    com.Parameters.AddWithValue("@soyad", uyeImcs.soyad);
                    com.Parameters.AddWithValue("@yas", uyeImcs.yas);
                    com.Parameters.AddWithValue("@cinsiyet", uyeImcs.cinsiyet);
                    com.Parameters.AddWithValue("@mail", uyeImcs.mail);
                    com.Parameters.AddWithValue("@sifre", uyeImcs.sifre);
                    com.Parameters.AddWithValue("@sifretekrar", uyeImcs.sifretekrar);
                    com.Parameters.AddWithValue("@tel", uyeImcs.tel);
                    com.Parameters.AddWithValue("@adres", uyeImcs.adres);
                    com.Parameters.AddWithValue("@il", uyeImcs.il);
                    com.Parameters.AddWithValue("@ilce", uyeImcs.ilce);
                    
                    com.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch(Exception hata)
            {
                MessageBox.Show("iŞLEM SIRASINDA HATA OLUŞTU" + hata);
            }

           
        }

        public void sil(int id)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            
            con = new SqlConnection(SqlCon);
            con.Open();
            com = new SqlCommand("Delete from TBLUyeIslemleri where uyeid=@id", con);
            com.Parameters.AddWithValue("@id",id);
            com.ExecuteNonQuery();
            con.Close();
          
            //katalog işlemlerini gerçekleştirmek
            //(örneğin, veritabanının yapısını sorgulamak veya tablolar gibi veritabanı nesneleri oluşturmak)
            //ya da UPDATE, INSERT veya DELETE deyimlerini yürüterek veritabanındaki
            //verileri kullanmadan DataSet değiştirmek için kullanabilirsinizExecuteNonQuery.

        }

        public DataGridView UyeListele (DataGridView dgvUye)
        { 
             con = new SqlConnection(SqlCon);
            string li = "Select *from TbLUyeIslemleri ";
            con.Open();
            da = new SqlDataAdapter(li, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvUye.DataSource = dt;
            con.Close();
            return dgvUye;
        }
       


       public void loginIslemi( LoginIslemleri lgnim) 
        {
            //Bir ya da birden fazla satırların sonuç olarak döneceği sorgularda 
            //    SqlCommand' ın ExecuteReader özelliği kullanılmaktadır.
            //    ExecuteReader geriye SqlDataReader tipinde veri döndürmektedir.

            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con = new SqlConnection(SqlCon);
                    con.Open();
                   string sorgu = "Select *From TBLUyeIslemleri where ad='"+lgnim.ad+"' And sifre='"+lgnim.sifre+"' And sifretekrar='"+lgnim.sifretekrar+"'";
                    com= new SqlCommand(sorgu,con);
                    //com.Parameters.AddWithValue("@ad", lgnim.ad);
                    //com.Parameters.AddWithValue("@sifre", lgnim.sifre);
                    //com.Parameters.AddWithValue("@sifretekrar", lgnim.sifretekrar);
                   dr= com.ExecuteReader();
                    if (dr.Read())
                    {
                       
                            MessageBox.Show("Giriş onaylandı");

                           EmanetIade emanetIade = new EmanetIade();
                           emanetIade.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Bilgilerinizi kontroll ediniz");
                    }
                    con.Close();
                }

            }
            catch (Exception hata)
            {
                MessageBox.Show("iŞLEM SIRASINDA HATA OLUŞTU" + hata);
            }



        }

        public void SifreUnttum(UyeIslemleriClasscs ui)
        {
            string a;
            con = new SqlConnection(SqlCon);
            con.Open();
            com = new SqlCommand("select *from TBLUyeIslemleri where ad='"+ui.ad+"' and mail='"+ui.mail+"'",con);
            dr= com.ExecuteReader();


            if (ui.ad!="" && ui.mail!="") {
                while (dr.Read()) {
                    try {
                        
                            a = dr["sifre"].ToString(); ;

                            MessageBox.Show("Şifreniz  " + a);
                       
                    }
                    catch
                    {
                        MessageBox.Show("bir hata");
                    }
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("bir hata");
            }
            
         
           
         
        }

    }
}
