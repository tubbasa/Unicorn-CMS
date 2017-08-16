using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("MenuLabel")]
  public  class MenuLabel:BaseEntity
    {
        [Display(Name = "Menu Label Adı")]
        public string Ad { get; set; }

        [Display(Name = "Menu Label Açıklaması")]
        public string Aciklama { get; set; }

    }
}
