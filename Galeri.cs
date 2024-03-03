using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasiG052
{
    //galeriye ait verilerin işlendiği/türetildiği/manipüle eidldiği kısım
    internal class Galeri
    {
        public List<Araba> Arabalar = new List<Araba>();
        public int ToplamArabaSayisi 
        {
            get
            {
                return this.Arabalar.Count;
            }
        }
        public int KiradakiArabaSayisi 
        { 
            get
            {
                int adet = 0;
                foreach (Araba item in this.Arabalar)
                {
                    if (item.Durum==DURUM.Kirada)
                    {
                        adet++;
                    }
                }
                return adet;
            } 
        
        }
        public int BekleyenArabaSayisi { get; set; }
        public int ToplamArabaKiralamaSuresi { get; set; }
        public int ToplamArabaKiralamaAdedi { get; set; }
        public int Ciro { get; set; }

        public void ArabaEkleme(string plaka, string marka, int kBedel, ARABATIPI aTipi)
        {
            //Araba a = new Araba(plaka, marka, kBedel, aTipi);
            //this.Arabalar.Add(a);

            this.Arabalar.Add(new Araba(plaka, marka, kBedel, aTipi));
        }

        public void ArabaKiralama(string plaka, int sure)
        {
            Araba a = null;
            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka==plaka)
                {
                    a = item;
                }
            }
            if (a!=null)
            {
                a.Durum = DURUM.Kirada;
                //a.KiralanmaSayisi++;
                //a.ToplamKiralanmaSuresi += sure;
                a.KiralanmaSureleri.Add(sure);
            }
        }
        public void ArabaTeslimAlma(string plaka)
        {
            Araba a = null;
            foreach (Araba item in this.Arabalar)
            {
                if (item.Plaka == plaka)
                {
                    a = item;
                }
            }
            if (a != null)
            {
                a.Durum = DURUM.Galeride;
                
            }
        }
    }
}
