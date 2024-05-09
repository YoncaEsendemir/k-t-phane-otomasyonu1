using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kutuphane
{
     class Sepet
    {
        public int KitapId { get; set; }
        public string BarKodno { get; set; }
        public string KitapAdi { get; set; }
        public string Yazar { get; set; }
        public string Yayinevi { get; set; }
        public int SayfaSayisi { get; set; }
        public int KitapSayisi { get; set; }
        public DateTime TeslimTarih { get; set; }
        public DateTime IadeTarih { get; set; }
    }

    class Emanet
    {
          public int UyeID { get; set; }
          public string Ad { get; set;} 
          public string Telefon{ get; set;}
          public int KitapID { get; set; }
          public string BarKodno { get; set; }
          public string Kitapadi { get; set; }
          public string Yazar { get; set; }
          public string Yayinevi { get; set; }
          public int SayfaSayisi { get; set; }
          public int KitapSayisi { get; set; }
          public DateTime TeslimTarih { get; set; }
          public DateTime IadeTarih { get; set; }



    }
}
