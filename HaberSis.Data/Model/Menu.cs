using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("Menu")]
    public class Menu:BaseEntity
    {
   

        
        public int MenuTipiId { get; set; }

        [Display(Name = "Menü Tipi")]
        public virtual MenuTip MenuTipi { get; set; }
        [Display(Name = "Menü Adı")]
        public string MenuAdi { get; set; }
        
        public virtual ICollection<MenuElemanlari> MenuElemanlari { get; set; }
    }
}
