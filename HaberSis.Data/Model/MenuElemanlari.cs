using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("MenuElemanlari")]
   public class MenuElemanlari : BaseEntity
    {
        [Display(Name= "Menu")]
        public Menu Menu { get; set; }

        public int MenuId { get; set; }

        [Display(Name = "Başlık")]
        public string Baslik { get; set; }

        public int ParentId { get; set; }

        public string UrlKEY { get; set; }

    }
}
