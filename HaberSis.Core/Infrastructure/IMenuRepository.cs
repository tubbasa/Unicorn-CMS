using HaberSis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Core.Infrastructure
{
   public interface IMenuRepository:IRepository<Menu>
    {
        ICollection<MenuElemanlari> MenuElemanlariniGetir(int MenuID);
    }
}
