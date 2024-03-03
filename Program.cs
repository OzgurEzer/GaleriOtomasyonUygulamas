using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;

namespace OtoGaleriUygulamasiG052
{
    //kullanıcı etkileşimi
    internal class Program
    {
        static Galeri Galeri052 = new Galeri();
        static void Main(string[] args)
        {
            Uygulama();
        }
        //static void SahteVeriGir()
        //{

        //    //Araba a = new Araba("35ARB3535", "OPEL", 150, "Sedan");
        //    //Galeri052.Arabalar.Add(a1);
        //    Galeri052.ArabaEkleme("35ARB3535", "OPEL", 150, ARABATIPI.Sedan);
        //    Galeri052.ArabaEkleme("25ARB3535", "FORD", 250, ARABATIPI.SUV);
        //    Galeri052.ArabaEkleme("45ARB3535", "FIAT", 350, ARABATIPI.Hatchback);
        //    Galeri052.ArabaEkleme("55ARB3535", "TOYOTA", 550, ARABATIPI.Hatchback);
        //    Galeri052.ArabaEkleme("65ARB3535", "HONDA", 450, ARABATIPI.Sedan);
        //    Galeri052.ArabaEkleme("75ARB3535", "FIAT", 850, ARABATIPI.SUV);
        //}
        static void Uygulama()
        {
            SahteVeriGir();
            Menu();
            while (true)
            {
                Console.WriteLine();
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();
                switch (secim.ToUpper())
                {
                    case "1":
                    case "K":
                        ArabaKirala();
                        break;

                    case "2":
                    case "T":
                        ArabaTeslimAl();
                        break;

                    case "3":
                    case "R":
                        KiradakiArabalar();
                        break;

                    case "4":
                    case "M":
                        GaleridekiArabalar();
                        break;

                    case "5":
                    case "A":
                        TümArabalarıListele();
                        break;

                    case "6":
                    case "I":
                        Kİralamaİptali();
                        break;

                    case "7":
                    case "Y":
                        ArabaEkle();
                        break;


                    case "8":
                    case "S":
                        ArabaSil();
                        break;

                    case "9":
                    case "G":
                        BilgileriGöster();
                        break;


                        //CıkısYapılacak();

                }
            }
        }
        static void SecimAL()
        {
            static string SecimAl()
            {
                // kullanıcının yaptığı seçimi almak için bu metodu oluşturduk.

                string karakterler = "123456789KTRMAIYSG";
                int sayac = 0;


                while (true)
                {
                    sayac++;
                    Console.Write("Seçiminiz : ");
                    string giris = Console.ReadLine().ToUpper();

                    int index = karakterler.IndexOf(giris);

                    Console.WriteLine();


                    if (giris.Length == 1 && index >= 0)
                    {
                        return giris;
                    }
                    else
                    {
                        if (sayac != 10)
                        {
                            Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                            Environment.Exit(0);

                        }
                        Console.WriteLine("Hatalı giriş yapıldı.");

                    }
                    Console.WriteLine();
                }

            }
        }
        static void Menu()
        {
            Console.WriteLine("Galeri Otomasyon                    ");
            Console.WriteLine("1 - Araba Kirala(K)                 ");
            Console.WriteLine("2 - Araba Teslim Al(T)              ");
            Console.WriteLine("3 - Kiradaki Arabaları Listele(R)   ");
            Console.WriteLine("4 - Galerideki Arabaları Listele(M) ");
            Console.WriteLine("5 - Tüm Arabaları Listele(A)        ");
            Console.WriteLine("6 - Kiralama İptali(I)              ");
            Console.WriteLine("7 - Araba Ekle(Y)                   ");
            Console.WriteLine("8 - Araba Sil(S)                    ");
            Console.WriteLine("9 - Bilgileri Göster(G)             ");


        }
        static void ArabaEkle()
        {
            Console.WriteLine("-Araba Ekle -  ");
            Console.WriteLine();
            //plaka alma metodu olmalı.. plaka formatı kontrol edilmeli
            Console.Write("Plaka: ");
            string plaka = "";

            Console.WriteLine();
            Console.Write("Marka: ");
            string marka = "";
            Console.Write("Kiralama Bedeli: ");
            int ucret = 120;
            Console.WriteLine("Araba Tipi:  ");
            Console.WriteLine("SUV için 1    ");
            Console.WriteLine("Hatchback için 2 ");
            Console.WriteLine("Sedan için 3     ");
            Console.WriteLine();
            Console.WriteLine("Araba Tipi: ");
            ARABATIPI aTip = ARABATIPI.Empty;
            Galeri052.ArabaEkleme(plaka, marka, ucret, aTip);

        }
        static void ArabaKirala()
        {

            Console.WriteLine("-Araba Kirala-");
            Console.WriteLine();

            if (Galeri052.Arabalar.Count == 0)
            {
                Console.WriteLine("Galeride hiç araba yok.");
                return;
            }

            if (Galeri052.GaleridekiAracSayisi == 0)
            {
                Console.WriteLine("Tüm araçlar kirada.");
                return;
            }

            string plaka;
            while (true)
            {
                plaka = Plaka("Kiralanacak arabanın plakası: ");
                if (plaka == "X")
                {
                    break;
                }

                if (OtoGaleri.DurumGetir(plaka) == "Kirada")
                {
                    Console.WriteLine("Araba şu anda kirada. Farklı araba seçiniz.");
                }
                else if (OtoGaleri.DurumGetir(plaka) == "ArabaYok")
                {
                    Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                }
                else
                {
                    int sure = AracGerecler.SayiAl("Kiralanma süresi: ");
                    OtoGaleri.ArabaKirala(plaka, sure);
                    Console.WriteLine();
                    Console.WriteLine(plaka.ToUpper() + " plakalı araba " + sure.ToString() + " saatliğine kiralandı.");
                }
            }
        }
        static void ArabaTeslimAl()
        {
            Console.WriteLine("-Araba Teslim Al -");
            Console.Write("Teslim alınacak arabanın plakası: ");

            //plaka olup olmadığını kontrol edecek bir metot
            //bu plakalı aracın kiralanmaya müsait olup olmadığını veya
            //galeride bu plakada bir araba olup olmadığını kontrol eden bir metot

            string plaka = "";

            Console.WriteLine();
            Galeri052.ArabaTeslimAlma(plaka);
        }
        static void KiradakiArabalar(DURUM)
        {
            Console.WriteLine("-Kiradaki Arabalar-");
            Console.WriteLine("                              ");
            Console.WriteLine("Plaka        Marka   K.Bedeli     Araba Tipi     K.sayısı      Durum  ");
            Console.WriteLine("                                                      ");
            Console.WriteLine("------------------------------------------------------------------------");
            foreach (Arabalar x in Araba)
            {
                Console.WriteLine(x.Plaka + "    " + x.Marka + "    " + x.KiraBedeli + "    " + x.ArabaTipi + "    " + x.KiralanmaSayisi+ "     "+x.DURUM);
            }



            static void Kiralamaİptlai()
            {
                Console.WriteLine("-Kiralama İptali-");
                Console.WriteLine("                                ");
                Console.WriteLine("Kiralaması iptal edilecek arabanın plakası: ");
                int plaka = Convert.ToInt32(Console.ReadLine());
                foreach (Araba item in Arabalar)
                {
                    if (item.Plaka == plaka)
                    {
                        Console.WriteLine("Kiralaması iptal edilecek arabanın plakası: + item.Ad");

                        string giris = Console.ReadLine().ToLower();
                        if (giris == "e")
                        {
                            ogrenciler.Remove(item);
                            Console.WriteLine("İptal gerçekleştirildi.  ");
                        }


                    }

                }

            }

            static void GaleridekiArabalar()
            {

            }
            static void TümArabalarıListele(DURUM)
            {

            }
            static void Kİralamaİptali()
            {
                Console.WriteLine("-Kiralama İptali-");
                Console.WriteLine();

                if (Galeri052.KiradakiAracSayisi == 0)
                {
                    Console.WriteLine("Kirada araba yok.");
                    return;
                }

                string plaka;
                while (true)
                {
                    plaka = PlakaAl("Kiralaması iptal edilecek arabanın plakası: ");
                    if (plaka == "X")
                    {
                        break;
                    }

                    if (Galeri052.DurumGetir(plaka) == "Galeride")
                    {
                        Console.WriteLine("Hatalı giriş yapıldı. Araba zaten galeride.");
                    }
                    else if (Galeri052.DurumGetir(plaka) == "ArabaYok")
                    {
                        Console.WriteLine("Galeriye ait bu plakada bir araba yok.");
                    }
                    else
                    {
                        Galeri052.KiralamaIptal(plaka);
                        Console.WriteLine();
                        Console.WriteLine("İptal gerçekleştirildi.");
                    }
                }
            }
            static void ArabaSil()
            {

            }
            static void BilgileriGöster()
            {
                Console.WriteLine("-Galeri Bilgileri-");
                Console.WriteLine("Toplam araba sayısı: " + Galeri052.ToplamArabaSayisi.ToString());
                Console.WriteLine("Kiradaki araba sayısı: " + Galeri052.KiradakiArabaSayisi.ToString());
                Console.WriteLine("Bekleyen araba sayısı: " + Galeri052.BekleyenArabaSayisi.ToString());
                Console.WriteLine("Toplam araba kiralama süresi: " + Galeri052.ToplamArabaKiralamaSuresi.ToString());
                Console.WriteLine("Toplam araba kiralama adedi: " + Galeri052.ToplamArabaKiralamaAdedi.ToString());
                Console.WriteLine("Ciro: " + Galeri052.Ciro.ToString());
            }












        }

    }
