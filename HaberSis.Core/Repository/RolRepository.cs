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
    public class RolRepository : IRolRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.Rol.Count();
        }

        public void Delete(int id)
        {
            var rol = GetById(id);
            if (rol!=null)
            {
                _context.Rol.Remove(rol);
            }
           
        }

        public Rol Get(Expression<Func<Rol, bool>> expression)
        {
            return _context.Rol.FirstOrDefault(expression);
        }

        public IEnumerable<Rol> GetAll()
        {
            return _context.Rol.Select(x=>x);
        }

        public Rol GetById(int id)
        {
            return _context.Rol.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Rol> GetMany(Expression<Func<Rol, bool>> expression)
        {
            return _context.Rol.Where(expression);
        }

        public void Insert(Rol obj)
        {
            _context.Rol.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Rol obj)
        {
            _context.Rol.AddOrUpdate();
        }
    }
}
