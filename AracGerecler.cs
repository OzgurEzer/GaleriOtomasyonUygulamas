using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoGaleriUygulamasiG052
{
    internal class AracGerecler
    {
        static public bool PlakaMi(string plaka)
        {
            if (plaka.Length>6 & plaka.Length<10 & SayiMi(plaka.Substring(0,2)) &HarfMi(plaka.Substring(0,2)))
            {

                if (plaka.Length ==7 & SayiMi(plaka.Substring(3)))
                {
                    return true;
                }
                else if (plaka.Length<9 & HarfMi(plaka.Substring(3,1)) & SayiMi(plaka.Substring(4)))
                {
                    return true;
                }
                else if (HarfMi(plaka.Substring(3,2)) & SayiMi(plaka.Substring(5)))   
                {
                    return true;
                }

            }
            return false;










        }
        
        static public bool HarfMi(string veri)
        {
            return true;
        }
        static public bool SayiMi(string veri)
        {
            return true;
        }






    }
}
