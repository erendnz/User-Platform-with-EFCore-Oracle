using ErenDenizEF.Data;
using ErenDenizEF.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Utilities
{
    // Bu sınıf, kullanıcı girişi (login) ile ilgili işlemleri gerçekleştiren yardımcı metodları içerir.
    //Eğer admin nesnesi null değilse (kullanıcı bulunmuşsa), giriş başarılı kabul edilir.
    internal static class LoginUtility
    {
        // Verilen LoginDTO nesnesi ile giriş yapmayı deneyen ve başarılı olup olmadığını döndüren metot.
        public static bool Login(LoginDTO login)
        {
            PlakciContext context = new PlakciContext();

            var admin = context.Adminler.FirstOrDefault(x => x.KullaniciAdi == login.KullaniciAdi && x.Sifre == SifreUtility.sha256_hash(login.Sifre));
            return !(admin == null);
        }

        // Kullanıcıdan kullanıcı adı ve şifre alarak bir LoginDTO nesnesi oluşturan metot.
        public static LoginDTO Login()
        {
            LoginDTO login = new LoginDTO();
            Console.Write("Kullanıcı Adını giriniz:");
            login.KullaniciAdi = Console.ReadLine();
            Console.Write("Sifre  giriniz:");
            login.Sifre = Console.ReadLine();

            return login;
        }
    }
}
