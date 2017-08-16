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
    public class MenuElemanlariRepository : IMenuElemanlariRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.MenuElemanlari.Count();
        }

        public void Delete(int id)
        {
            var silinecek = _context.MenuElemanlari.FirstOrDefault(x => x.ID == id);
            if (silinecek != null)
            {
                _context.MenuElemanlari.Remove(silinecek);
            }
        }

        public MenuElemanlari Get(Expression<Func<MenuElemanlari, bool>> expression)
        {
            return _context.MenuElemanlari.FirstOrDefault(expression);
        }

        public IEnumerable<MenuElemanlari> GetAll()
        {
            return _context.MenuElemanlari.Select(x => x);
        }

        public MenuElemanlari GetById(int id)
        {
            return _context.MenuElemanlari.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<MenuElemanlari> GetMany(Expression<Func<MenuElemanlari, bool>> expression)
        {
            return _context.MenuElemanlari.Where(expression);
        }

        public void Insert(MenuElemanlari obj)
        {
            _context.MenuElemanlari.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MenuElemanlari obj)
        {
            _context.MenuElemanlari.AddOrUpdate();
        }
    }
}
