using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("Kategori")]
    public class Kategori:BaseEntity
    {
      

        [MinLength(2, ErrorMessage ="{0} karakterden az olamaz."),MaxLength(150,ErrorMessage ="150 karakterden fazla giremezsiniz.")]
        [Required]
        public string KategoriAdi { get; set; }

        public int ParentID { get; set; }

        [MinLength(2, ErrorMessage = "{0} karakterden az olamaz."), MaxLength(150, ErrorMessage = "150 karakterden fazla giremezsiniz.")]
        public string Url { get; set; }

        public virtual  ICollection<Haber> Haber { get; set; }

        //public virtual Kullanici Kullanici { get; set; }






    }
}
