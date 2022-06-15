using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class O
    {
        public O()
        {
            Builds = new HashSet<Build>();
        }
        [Required]
        [Display(Name = "Id операционной системы")]
        public int IdOs { get; set; }
        [Required]
        [Display(Name = "Название операционной системы")]
        public string NameOs { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Семейство операционной системы")]
        public string Family { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
