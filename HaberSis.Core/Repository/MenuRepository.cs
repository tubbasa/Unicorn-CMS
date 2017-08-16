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
    public class MenuRepository : IMenuRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.Menu.Count();
        }

        public void Delete(int id)
        {
            var silinecek = _context.Menu.FirstOrDefault(x => x.ID == id);
            if (silinecek != null)
            {
                _context.Menu.Remove(silinecek);
            }
        }

        public Menu Get(Expression<Func<Menu, bool>> expression)
        {
            return _context.Menu.FirstOrDefault(expression);
        }

        public IEnumerable<Menu> GetAll()
        {
            return _context.Menu.Select(x => x);
        }

        public Menu GetById(int id)
        {
            return _context.Menu.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Menu> GetMany(Expression<Func<Menu, bool>> expression)
        {
            return _context.Menu.Where(expression);
        }

        public void Insert(Menu obj)
        {
            _context.Menu.Add(obj);
        }

        public ICollection<MenuElemanlari> MenuElemanlariniGetir(int MenuID)
        {
            return _context.MenuElemanlari.Where(x=>x.MenuId==MenuID).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Menu obj)
        {
            _context.Menu.AddOrUpdate();
        }
    }
}
