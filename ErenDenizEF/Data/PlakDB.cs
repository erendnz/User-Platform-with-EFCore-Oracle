using ErenDenizEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Data
{
    internal class PlakDB
    {
        public BaseManager<Album> Albumler { get; set; }
        public BaseManager<Sanatci> Sanatcilar { get; set; }
        public BaseManager<Admin> Adminler { get; set; }

        public PlakDB()
        {
            Albumler = new BaseManager<Album>();
            Adminler = new BaseManager<Admin>();
            Sanatcilar = new BaseManager<Sanatci>();
        }
    }
}
