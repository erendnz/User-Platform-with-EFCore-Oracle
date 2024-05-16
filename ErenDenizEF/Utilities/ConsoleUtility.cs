using ErenDenizEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Utilities
{
    internal static class ConsoleUtility
    {
        // Album verilerini kullanıcıdan alarak bir Album nesnesi oluşturan metot
        public static Album AlbumVerisiAl()
        {
            Album album = new Album();

            Console.Write("Album Id si Giriniz ");
            album.AlbumId = int.Parse(Console.ReadLine());

            Console.Write("Album Adi Giriniz");
            album.AlbumAdi = Console.ReadLine();

            Console.Write("Fiyat  Giriniz");
            album.Fiyat = double.Parse(Console.ReadLine());

            Console.Write("Sanatci Id Giriniz");
            album.SanatciId = int.Parse(Console.ReadLine());

            Console.Write("Indirim Orani Giriniz");
            album.IndirimOrani = double.Parse(Console.ReadLine());

            return album;
        }

        // Generic olarak tanımlanan liste elemanlarını ekrana yazdıran metot
        public static void Listele<T>(List<T> liste)
        {
            foreach (var item in liste)
            {
                Console.WriteLine(item);
            }
        }

        // Sanatçı verilerini kullanıcıdan alarak bir Sanatci nesnesi oluşturan metot
        public static Sanatci SanatciVerisiAl()
        {
            Sanatci sanatci = new Sanatci();
            Console.Write("Sanatci Id si Giriniz ");
            sanatci.SanatciId = int.Parse(Console.ReadLine());
            Console.Write("Sanatci Adi  Giriniz");
            sanatci.SanatciAdi = Console.ReadLine();

            return sanatci;
        }

        // Admin verilerini kullanıcıdan alarak bir Admin nesnesi oluşturan metot
        public static Admin AdminVerisiAl()
        {
            Admin admin = new Admin();
            Console.Write("Admin Id si Giriniz ");
            admin.AdminID = int.Parse(Console.ReadLine());
            Console.Write("Admin Adi  Giriniz");
            admin.Ad = Console.ReadLine();
            Console.Write("Admin Soyadi  Giriniz");
            admin.Soyad = Console.ReadLine();
            Console.Write("Admin Kullanici Adi Giriniz");
            string kullaniciAdi = Console.ReadLine();
            while (SifreUtility.KullaniciAdiBaskaVarMıKontrolu(kullaniciAdi))
            {
                Console.WriteLine("Kullanıcı adı zaten sistemde kayıtlı. Yeni bir kullanici adi giriniz");
                kullaniciAdi = Console.ReadLine();
            }
            admin.KullaniciAdi = kullaniciAdi;
            Console.Write("Admin Sifre Giriniz");
            string sifre1 = Console.ReadLine();
            while (!SifreUtility.SifreUzunlukKontrolu(sifre1))
            {
                Console.WriteLine("Sifre en az 8 karakter uzunluğunda olmalıdır. Yeni bir sifre giriniz");
                sifre1 = Console.ReadLine();
            }
            Console.WriteLine("Sifrenizi tekrar giriniz");
            string sifre2 = Console.ReadLine();
            while (sifre1 != sifre2)
            {
                Console.WriteLine("Sifreler aynı olmalıdır. Sifreyi tekrar giriniz");
                sifre2 = Console.ReadLine();
            }
            admin.Sifre = Utilities.SifreUtility.sha256_hash(sifre1);

            return admin;
        }

        // Kullanıcıya menü seçeneklerini gösteren ve seçimini alan metot
        public static int Menu()
        {
            int secim = 0;

            Console.WriteLine("1-Album Ekle");
            Console.WriteLine("2-Album Guncelle");
            Console.WriteLine("3-Album Sil");
            Console.WriteLine("4-Sanatci Ekle");
            Console.WriteLine("5-Sanatci Guncelle");
            Console.WriteLine("6-Sanatci Sil");
            Console.WriteLine("7-Tum Albumleri Listele");
            Console.WriteLine("8-Tum Sanatcilari Listele");
            Console.WriteLine("9-En son eklenen 10 Album");
            Console.WriteLine("10-Album Satisi Durdur");
            Console.WriteLine("11-Satisi Durdurulan Albumler");
            Console.WriteLine("12-Satisi Devam Eden Albumler");
            Console.WriteLine("13-Indirimdeki Albumler");
            Console.WriteLine("14-Yeni Admin Ekle");
            Console.WriteLine("15-Admin Guncelle");
            Console.WriteLine("16-Admin Sil");
            Console.WriteLine("17-Adminleri Listele");
            Console.WriteLine("18-Cikis");

            Console.WriteLine("SECIMINIZ ");
            secim = int.Parse(Console.ReadLine());

            return secim;
        }
    }
}
