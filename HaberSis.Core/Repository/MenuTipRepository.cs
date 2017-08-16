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
    public class MenuTipRepository : IMenuTipRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.MenuTip.Count();
        }

        public void Delete(int id)
        {

            var silinecek = _context.MenuTip.FirstOrDefault(x => x.ID == id);
            if (silinecek != null)
            {
                _context.MenuTip.Remove(silinecek);
            }
        }

        public MenuTip Get(Expression<Func<MenuTip, bool>> expression)
        {
            return _context.MenuTip.FirstOrDefault(expression);
        }

        public IEnumerable<MenuTip> GetAll()
        {
            return _context.MenuTip.Select(x => x);
        }

        public MenuTip GetById(int id)
        {
            return _context.MenuTip.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<MenuTip> GetMany(Expression<Func<MenuTip, bool>> expression)
        {
            return _context.MenuTip.Where(expression);
        }

        public void Insert(MenuTip obj)
        {
            _context.MenuTip.Add(obj);
        }

        public ICollection<MenuElemanlari> MenuElemanlariniGetir(int MenuID)
        {
            return _context.MenuElemanlari.Where(x=>x.MenuId==MenuID).ToList();
        }

        public ICollection<Menu> MenuleriGetir(int MenuTipID)
        {
            return _context.Menu.Where(x=>x.MenuTipi.ID==MenuTipID).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(MenuTip obj)
        {
            _context.MenuTip.AddOrUpdate();
        }
    }
}
