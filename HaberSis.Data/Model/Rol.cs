using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("Rol")]
    public class Rol:BaseEntity
    {
    
        [Display(Name = "Rol Adı:")]
        [MinLength(3, ErrorMessage = "Lütfen 3 karakterden az girmeyin"), MaxLength(150, ErrorMessage = "150 karakterden fazla giremezsiniz")]
        public string RolAdi { get; set; }

    }
}
