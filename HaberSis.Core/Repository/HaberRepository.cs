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
  
    public class HaberRepository : IHaberRepository
    {
        private readonly HaberContext  _context= new HaberContext();
        public int count()
        {
            return _context.Haber.Count();
        }

        public void Delete(int id)
        {
            var haber = GetById(id);
            if (haber!=null)
            {
                _context.Haber.Remove(haber);
            }
        }

        public Haber Get(Expression<Func<Haber, bool>> expression)
        {
            return _context.Haber.FirstOrDefault(expression);
        }

        public IEnumerable<Haber> GetAll()
        {
            return _context.Haber.Select(x=>x);
        }

        public Haber GetById(int id)
        {
            return _context.Haber.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Haber> GetMany(Expression<Func<Haber, bool>> expression)
        {
            return _context.Haber.Where(expression);
        }

        public void Insert(Haber obj)
        {
            _context.Haber.Add(obj);
          
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Haber obj)
        {
            _context.Haber.AddOrUpdate();
        }
    }
}
