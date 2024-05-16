using ErenDenizEF.Data;
using ErenDenizEF.Enums;
using ErenDenizEF.Models;
using ErenDenizEF.Utilities;
using System;
using System.Drawing;

// Kullanıcıdan giriş bilgilerini alır ve kontrol eder.
var login = LoginUtility.Login();
if (LoginUtility.Login(login))
{
    Console.WriteLine("Kullanıcı var...");
    int secim = 0;

    do
    {
        // Menüyü gösterir ve kullanıcının seçimini alır
        secim = ConsoleUtility.Menu();
        PlakDB plakDB = new PlakDB();
        string eminMisiniz;
        int id;
        switch (secim)
        {
            case 1:
                // Yeni bir albüm ekleyen metod
                plakDB.Albumler.Ekle(ConsoleUtility.AlbumVerisiAl());
                break;

            case 2:
                // Albüm güncelleyen metod
                Console.WriteLine("Guncellenecek albumun ID sini giriniz.. ");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine("Album...");
                Console.WriteLine(plakDB.Albumler.Bul(id));

                Album album = ConsoleUtility.AlbumVerisiAl();
                album.AlbumId = id;
                plakDB.Albumler.Guncelle(album);
                break;

            case 3:
                //Albümü silen metod
                Console.WriteLine("Silinecek albumun ID sini giriniz.. ");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine("Album Bilgileri...");
                Console.WriteLine(plakDB.Albumler.Bul(id));


                Console.WriteLine("Bu verileri silmek istiyor musunuz?");
                eminMisiniz = Console.ReadLine();

                if (eminMisiniz == "E" || eminMisiniz == "e")
                    plakDB.Albumler.Sil(id);
                break;

            case 4:
                //Sanatci ekleyen metod+
                plakDB.Sanatcilar.Ekle(ConsoleUtility.SanatciVerisiAl());
                break;

            case 5:
                //Sanatci güncelleyen metod
                Console.WriteLine("Guncellenecek sanatcinin ID sini giriniz.. ");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine("Eski Degerler...");
                Console.WriteLine(plakDB.Sanatcilar.Bul(id));

                Sanatci sanatci = ConsoleUtility.SanatciVerisiAl();
                sanatci.SanatciId = id;
                plakDB.Sanatcilar.Guncelle(sanatci);
                break;

            case 6:
                // Sanatciyi silen metod
                Console.WriteLine("Silinecek sanatcinin ID sini giriniz.. ");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine("Sanatci Bilgileri...");
                Console.WriteLine(plakDB.Sanatcilar.Bul(id));


                Console.WriteLine("Bu verileri silmek istiyor musunuz?");
                eminMisiniz = Console.ReadLine();

                if (eminMisiniz == "E" || eminMisiniz == "e")
                    plakDB.Sanatcilar.Sil(id);
                break;

            case 7:
                //Albumleri Listeleyen metod
                ConsoleUtility.Listele(plakDB.Albumler.ListeleJOIN("Sanatci")
                .Select(x => new { x.AlbumId ,x.AlbumAdi, x.AlbumDurumu, x.CikisTarihi,
                    x.Fiyat, x.IndirimOrani , x.SanatciId,
                    x.Sanatci.SanatciAdi }).ToList());
                Console.ReadLine();

                ConsoleUtility.Listele(plakDB.Albumler.ListeleJOIN("Sanatci")
                    .Where(x => x.AlbumDurumu == AlbumDurumu.Aktif)
                    .OrderByDescending(x => x.CikisTarihi)
                    .Take(10).Select(x => new { x.AlbumAdi, x.Sanatci.SanatciAdi }).ToList());
                break;

            case 8:
                //Sanatcilari listeleyen metod
                ConsoleUtility.Listele(plakDB.Sanatcilar.ListeleJOIN("Albumler"));
                Console.ReadLine();
                break;

            case 9:
                //Son eklenen 10 albumu listeleyen metod
                ConsoleUtility.Listele(plakDB.Albumler.ListeleJOIN("Sanatci")
                    .Where(x => x.AlbumDurumu == AlbumDurumu.Aktif)
                    .OrderByDescending(x => x.CikisTarihi)
                    .Take(10).Select(x => new { x.AlbumAdi, x.Sanatci.SanatciAdi }).ToList());
                break;

            case 10:
                //Album satisini durduran metod
                Console.WriteLine("Album ID giriniz");
                id = int.Parse(Console.ReadLine());

                var satisiDurdurulacakAlbum = plakDB.Albumler.Bul(id);
                satisiDurdurulacakAlbum.AlbumDurumu = AlbumDurumu.Pasif;
                plakDB.Albumler.Guncelle(satisiDurdurulacakAlbum);
                break;

            case 11:
                //Satisi devam eden albumleri listeleyen metod
                ConsoleUtility.Listele(plakDB.Albumler.ListeleJOIN("Sanatci")
                    .Where(x => x.AlbumDurumu == AlbumDurumu.Pasif)
                    .Select(x => new { x.AlbumAdi , x.Sanatci.SanatciAdi}).ToList()); 
                break;

            case 12:
                //Satisi Durdurulan Albumleri Listeleyen metod
                ConsoleUtility.Listele(plakDB.Albumler.ListeleJOIN("Sanatci")
                    .Where(x => x.AlbumDurumu == AlbumDurumu.Aktif)
                    .Select(x => new { x.AlbumAdi, x.Sanatci.SanatciAdi }).ToList());
                break;

            case 13:
                //Indirimdeki albumleri listeleyen metod
                var indirimdekiAlbumler = plakDB.Albumler.ListeleJOIN("Sanatci")
                    .Where(x => x.IndirimOrani != 0 && x.AlbumDurumu == AlbumDurumu.Aktif)
                    .OrderByDescending(x=>x.IndirimOrani)
                    .Select(x => new { x.AlbumAdi, x.Sanatci.SanatciAdi });

                if (indirimdekiAlbumler.Count() == 0)
                {
                    Console.WriteLine("İndirimde Albüm Yok");
                }

                else
                {
                    ConsoleUtility.Listele(indirimdekiAlbumler.ToList());
                }
                break;

            case 14:
                //Admin ekleyen metod
                plakDB.Adminler.Ekle(ConsoleUtility.AdminVerisiAl());
                break;

            case 15:
                //Admin guncelleyen metod
                Console.WriteLine("Guncellenecek adminin ID sini giriniz.. ");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine("Admin...");
                Console.WriteLine(plakDB.Adminler.Bul(id));

                Admin admin = ConsoleUtility.AdminVerisiAl();
                admin.AdminID = id;
                plakDB.Adminler.Guncelle(admin);
                break;

            case 16:
                //Admin silen metod
                Console.WriteLine("Silinecek adminin ID sini giriniz.. ");
                id = int.Parse(Console.ReadLine());

                Console.WriteLine("Admin Bilgileri...");
                Console.WriteLine(plakDB.Adminler.Bul(id));


                Console.WriteLine("Bu verileri silmek istiyor musunuz?");
                eminMisiniz = Console.ReadLine();

                if (eminMisiniz == "E" || eminMisiniz == "e")
                    plakDB.Adminler.Sil(id);
                break;

            case 17:
                //Adminleri listeleyen metod
                ConsoleUtility.Listele(plakDB.Adminler.Listele());
                Console.ReadLine();
                break;
        }
    } while (secim != 18);
}
// Kullanıcı bilgileri bulunamadıgında hata mesajı verir
else
    Console.WriteLine("Kullanıcı Id ve parola hatalı");