using ErenDenizEF.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Models
{
    internal class Album
    {
        public int AlbumId { get; set; }
        public string AlbumAdi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public double Fiyat { get; set; }
        public double IndirimOrani { get; set; }
        public AlbumDurumu AlbumDurumu { get; set; }
        public int SanatciId { get; set; }
        public Sanatci Sanatci { get; set; }

        //Yeni album nesnesi olusturuldugu anda Cikis Tarihi şu anki zaman olarak ayarlanır
        public Album()
        {
            CikisTarihi = DateTime.Now;
        }

        public override string ToString()
        {
            return $"Album Id={AlbumId} Album Adi={AlbumAdi} Cikis Tarihi ={CikisTarihi}" +
                $"Fiyat = {Fiyat} Indirim Orani = {IndirimOrani} Album Durumu = {AlbumDurumu}" +
                $"Sanatci Id = {SanatciId}";
        }
    }
}
