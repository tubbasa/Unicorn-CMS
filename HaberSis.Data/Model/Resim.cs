using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberSis.Data.Model
{
    [Table("Resim")]
   public  class Resim:BaseEntity
    {
       

        public string ResimUrl { get; set; }

        public Haber Haber { get; set; }

        public int HaberId { get; set; }


    }
}
