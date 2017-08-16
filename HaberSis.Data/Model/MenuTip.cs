using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("MenuTip")]
   public class MenuTip:BaseEntity
    {
        [Display(Name ="Menü Tip Adı")]
        public string TipAdi { get; set; }
        public virtual ICollection<Menu> Menu { get; set; }

    }
}
