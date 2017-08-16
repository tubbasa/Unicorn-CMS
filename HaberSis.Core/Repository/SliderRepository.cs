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
    public class SliderRepository : ISliderRepository
    {
        private readonly HaberContext _context = new HaberContext();
        public int count()
        {
            return _context.Slider.Count();
        }

        public void Delete(int id)
        {
            var silinecek = _context.Slider.FirstOrDefault(x => x.ID == id);
            if (silinecek != null)
            {
                _context.Slider.Remove(silinecek);
            }
        }

        public Slider Get(Expression<Func<Slider, bool>> expression)
        {
            return _context.Slider.FirstOrDefault(expression);
        }

        public IEnumerable<Slider> GetAll()
        {
            return _context.Slider.Select(x => x);
        }

        public Slider GetById(int id)
        {
            return _context.Slider.FirstOrDefault(x => x.ID == id);
        }

        public IQueryable<Slider> GetMany(Expression<Func<Slider, bool>> expression)
        {
            return _context.Slider.Where(expression);
        }

        public void Insert(Slider obj)
        {
            _context.Slider.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Slider obj)
        {
            _context.Slider.AddOrUpdate();
        }
    }
}
