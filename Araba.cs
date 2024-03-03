using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasiG052
{
    internal class Araba
    {
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public int KiraBedeli { get; set; }
        public ARABATIPI ArabaTipi { get; set; }
        public DURUM Durum { get; set; }
        public int KiralanmaSayisi
        {
            get
            {
                return this.KiralanmaSureleri.Count;
            }
        }
        public int ToplamKiralanmaSuresi 
        { 
            get
            {
                int toplam = 0;
                foreach (int item in this.KiralanmaSureleri)
                {
                    toplam += item;
                }
                return toplam;
            }
        }
        public List<int> KiralanmaSureleri = new List<int>();

        public Araba()
        {
            this.Durum = DURUM.Galeride;
        }
        public Araba(string plaka, string marka, int kBedeli, ARABATIPI aracTipi)
        {
            this.Plaka = plaka;
            this.Marka = marka;
            this.ArabaTipi = aracTipi;
            this.KiraBedeli = kBedeli;
            this.Durum = DURUM.Galeride;
        }
    }
    enum ARABATIPI
    {
        Empty, SUV, Hatchback, Sedan
    }
    enum DURUM
    {
        Empty, Galeride, Kirada
    }
}
