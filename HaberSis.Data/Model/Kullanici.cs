using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("Kullanici")]
    public class Kullanici:BaseEntity
    {
      
        [MaxLength(150,ErrorMessage ="Lütfen 150 karakterden fazla değer girmeyiniz")]
        [Display(Name ="Ad Soyad")]
        public string AdSoyad { get; set; }

        [Display(Name ="E-mail")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",ErrorMessage ="Geçerli bir mail adresi giriniz!")]
        public string Email { get; set; }

        [Display(Name ="Şifre")]
        [DataType(DataType.Password)]
        [MaxLength(16, ErrorMessage = "Lütfen 16 karakterden fazla değer girmeyiniz")]
        [Required]
        public string Sifre { get; set; }
 
        public virtual Rol Rol { get; set; }
    }
}
