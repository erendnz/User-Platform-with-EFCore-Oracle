using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErenDenizEF.Data
{
    // BaseEntity sınıfından türetilmiş, genel CRUD işlemlerini gerçekleştiren sınıf.
    internal class BaseManager<TEntity> : ICRUD<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet; // Generic türdeki DbSet nesnesi, varlıkları temsil eder.
        private PlakciContext _context; // Entity Framework DbContext nesnesi, veritabanı işlemlerini yönetir.

        public BaseManager()
        {
            _context = new PlakciContext();
            _dbSet = _context.Set<TEntity>();
        }

        // Belirtilen ID'ye sahip varlığı bulan ve detaylarını alma işlemlerini gerçekleştiren metot.
        public TEntity Bul(int entityID)
        {
            var x = _dbSet.Find(entityID);
            _context.Entry(x).State = EntityState.Detached; // Detached durumu, nesnenin takip edilmemesini sağlar.
            return x;
        }

        // Yeni bir varlık ekleyen metot.
        public void Ekle(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        // Varlığı güncelleyen metot.
        public void Guncelle(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        // Belirtilen tablo ile birleştirilmiş (JOIN) varlıkları listelemeyi gerçekleştiren metot.
        public List<TEntity> ListeleJOIN(string tabloAdi)
        {
            return _dbSet.Include(tabloAdi).ToList();
        }

        // Tüm varlıkları listelemeyi gerçekleştiren metot.
        public List<TEntity> Listele()
        {
            return _dbSet.ToList();
        }

        // Belirli bir koşulu sağlayan varlıkları listelemeyi gerçekleştiren metot.
        public List<TEntity> Listele(Func<TEntity, bool> predicate)
        {
            return _dbSet.Include("Kategori").Where(predicate).ToList();
        }

        // Belirtilen ID'ye sahip varlığı silen metot.
        public void Sil(int entityID)
        {
            _dbSet.Remove(_dbSet.Find(entityID));
            _context.SaveChanges();
        }
    }
}
