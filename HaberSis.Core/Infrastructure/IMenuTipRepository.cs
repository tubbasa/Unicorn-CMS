using HaberSis.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Core.Infrastructure
{
   public interface IMenuTipRepository:IRepository<MenuTip>
    {

         ICollection<Menu> MenuleriGetir(int MenuTipID);

        ICollection<MenuElemanlari> MenuElemanlariniGetir(int MenuID);
    }
}
