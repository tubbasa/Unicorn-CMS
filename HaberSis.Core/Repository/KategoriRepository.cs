using HaberSis.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaberSis.Data.Model;
using System.Linq.Expressions;
using HaberSis.Data.DataContext;
using System.Data.Entity.Migrations;

namespace HaberSis.Core.Repository
{
   public class KategoriRepository : IKategoriRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.Kategori.Count();
        }

        public void Delete(int id)
        {
            var silinecek = _context.Kategori.FirstOrDefault(x=>x.ID==id);
            if (silinecek!=null)
            {
                _context.Kategori.Remove(silinecek);
            }
        }

        public Kategori Get(Expression<Func<Kategori, bool>> expression)
        {
            return _context.Kategori.FirstOrDefault(expression);
        }

        public IEnumerable<Kategori> GetAll()
        {
            return _context.Kategori.Select(x=>x);
        }

        public Kategori GetById(int id)
        {
            return _context.Kategori.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Kategori> GetMany(Expression<Func<Kategori, bool>> expression)
        {
            return _context.Kategori.Where(expression);
        }

        public void Insert(Kategori obj)
        {
            _context.Kategori.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Kategori obj)
        {
            _context.Kategori.AddOrUpdate();
        }
    }
}
