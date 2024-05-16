using ErenDenizEF.Enums;
using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Models
{
    internal class Sanatci
    {
        public int SanatciId { get; set; }
        public string SanatciAdi { get; set; }
        public ICollection<Album> Albumler { get; set; }

        public override string ToString()
        {
            return $"Sanatci Id={SanatciId} SanatciAdi={SanatciAdi}";
        }
    }
}
