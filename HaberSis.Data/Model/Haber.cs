using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("Haber")]
    public class Haber: BaseEntity
    {
       

        [Display(Name ="Haber Başlık")]
        [MaxLength(255,ErrorMessage ="Fazla oldu")]
        [Required]
        public string Baslik { get; set; }

        [Display(Name = "Kısa Açıklama")]
        public string KisaAciklama { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }

        [Display(Name = "Okunma Sayısı")]
        public int Okunma { get; set; }

        public int KullaniciId { get; set; }
        
        [Display(Name = "Kullanıcı")]
        public virtual Kullanici Kullanici { get; set; }

        [Display(Name = "Resim")]
        [MaxLength(255,ErrorMessage ="255 karakterden fazla olamaz")]
        public string Resim { get; set; }

        public virtual ICollection<Resim> Resimler { get; set; }

        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }

        public virtual ICollection<Etiket> Etiket{ get; set; }


    }
}
