using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Data
{
    // Genel CRUD (Create, Read, Update, Delete) işlemlerini
    // gerçekleştirmek için arayüz (interface) tanımlayan sınıf.
    internal interface ICRUD<TEntity> where TEntity : class
    {
        void Ekle(TEntity entity);
        void Guncelle(TEntity entity);
        void Sil(int entityID);

        List<TEntity> Listele();
        List<TEntity> ListeleJOIN(string tabloAdi);
        TEntity Bul(int entityID);

        List<TEntity> Listele(Func<TEntity, bool> predicate);
    }
}
