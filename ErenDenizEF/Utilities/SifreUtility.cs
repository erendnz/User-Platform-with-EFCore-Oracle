using ErenDenizEF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Utilities
{
    // Bu sınıf, şifreleme ve şifre/kullanıcı adı kontrolü ile ilgili yardımcı metodları içerir.
    internal static class SifreUtility
    {
        // SHA256Managed sınıfı kullanılarak şifre hash'lenir ve hexadecimal formatına dönüştürülerek döndürülür.
        public static string sha256_hash(string sifre)
        {
            
            using (SHA256 hash = SHA256Managed.Create())
            {
                return string.Concat(hash.ComputeHash(Encoding.UTF8.GetBytes(sifre))
                    .Select(l => l.ToString("X2")));
            }
        }

        // Şifre uzunluğu 8 karakterden fazla ise true, değilse false döndürülür.
        public static bool SifreUzunlukKontrolu(string sifre)
        {
            return sifre.Length >= 8;
        }

        // Verilen kullanıcı adının veritabanında başka bir kayıtta olup olmadığını kontrol eden metot
        // Eğer kullanıcı adı varsa, true döndür; yoksa false döndür
        public static bool KullaniciAdiBaskaVarMıKontrolu(string kullaniciAdi)
        {
            using (PlakciContext context = new PlakciContext())
            {
                bool kullaniciAdiVarMi = context.Adminler.Any(x => x.KullaniciAdi == kullaniciAdi);
                return kullaniciAdiVarMi;
            }
        }
    }
}
