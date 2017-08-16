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
   public class KullaniciRepository : IKullaniciRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.Kullanici.Count();
        }

        public void Delete(int id)
        {
            var kullanici = GetById(id);
            if (kullanici!=null)
            {
                _context.Kullanici.Remove(kullanici);
            }
        }

        public Kullanici Get(Expression<Func<Kullanici, bool>> expression)
        {
            return _context.Kullanici.FirstOrDefault(expression);
        }

        public IEnumerable<Kullanici> GetAll()
        {
            return _context.Kullanici.Select(x=>x);
        }

        public Kullanici GetById(int id)
        {
            return _context.Kullanici.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Kullanici> GetMany(Expression<Func<Kullanici, bool>> expression)
        {
            return _context.Kullanici.Where(expression);
        }

        public void Insert(Kullanici obj)
        {
            _context.Kullanici.Add(obj);
          
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Kullanici obj)
        {
            _context.Kullanici.AddOrUpdate();
        }
    }
}
