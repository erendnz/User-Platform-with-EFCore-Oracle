using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Models
{
    internal class Admin
    {
        public int AdminID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }

        public override string ToString()
        {
            return $"Admin Id = {AdminID} Admin Ismi = {Ad} {Soyad} Kullanıcı adı = {KullaniciAdi}" +
                $"Sifre = {Sifre}";
        }
    }
}
