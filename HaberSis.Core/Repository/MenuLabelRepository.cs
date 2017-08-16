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
    public class MenuLabelRepository : IMenuLabelRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.MenuLabel.Count();
        }

        public void Delete(int id)
        {
            var silinecek = _context.MenuLabel.FirstOrDefault(x => x.ID == id);
            if (silinecek != null)
            {
                _context.MenuLabel.Remove(silinecek);
            }
        }

        public MenuLabel Get(Expression<Func<MenuLabel, bool>> expression)
        {
            return _context.MenuLabel.FirstOrDefault(expression);
        }

        public IEnumerable<MenuLabel> GetAll()
        {
            return _context.MenuLabel.Select(x => x);
        }

        public MenuLabel GetById(int id)
        {
            return _context.MenuLabel.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<MenuLabel> GetMany(Expression<Func<MenuLabel, bool>> expression)
        {
            return _context.MenuLabel.Where(expression);
        }

        public void Insert(MenuLabel obj)
        {
            _context.MenuLabel.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MenuLabel obj)
        {
            _context.MenuLabel.AddOrUpdate();
        }
    }
}
