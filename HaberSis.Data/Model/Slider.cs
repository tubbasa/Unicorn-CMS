using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("Slider")]
   public class Slider :BaseEntity
    {
        [Display(Name ="Başlık")]
        [MinLength(3,ErrorMessage ="En az {0} karakter girebilirsiniz"),MaxLength(255,ErrorMessage ="Maximum 255 karakter girebilirsiniz")]
        public string Baslik { get; set; }

        [Display(Name = "Url")]
        [MinLength(3, ErrorMessage = "En az {0} karakter girebilirsiniz"), MaxLength(255, ErrorMessage = "Maximum 255 karakter girebilirsiniz")]
        public string Url { get; set; }

        [Display(Name = "Açıklama")]
        [MinLength(3, ErrorMessage = "En az {0} karakter girebilirsiniz"), MaxLength(255, ErrorMessage = "Maximum 255 karakter girebilirsiniz")]
        public string Aciklama { get; set; }

        [Display(Name = "Resim")]
        [MinLength(3, ErrorMessage = "En az {0} karakter girebilirsiniz"), MaxLength(255, ErrorMessage = "Maximum 255 karakter girebilirsiniz")]
        [Required]
        public string ResimUrl { get; set; }
    }
}
