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
    public class ResimRepository : IResimRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.Resim.Count();
        }

        public void Delete(int id)
        {
            var resim = GetById(id);
            if (resim!=null)
            {
                _context.Resim.Remove(resim);
            }
        }

        public Resim Get(Expression<Func<Resim, bool>> expression)
        {
            return _context.Resim.FirstOrDefault(expression);
        }

        public IEnumerable<Resim> GetAll()
        {
            return _context.Resim.Select(x=>x);
        }

        public Resim GetById(int id)
        {
           return _context.Resim.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Resim> GetMany(Expression<Func<Resim, bool>> expression)
        {
            return _context.Resim.Where(expression);
        }

        public void Insert(Resim obj)
        {
            _context.Resim.Add(obj);
          
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Resim obj)
        {
            _context.Resim.AddOrUpdate();
        }
    }
}
