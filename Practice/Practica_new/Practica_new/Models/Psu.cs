using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Psu
    {
        public Psu()
        {
            Builds = new HashSet<Build>();
        }
        [Required]
        [Display(Name = "Id блока питания")]
        public int IdPsu { get; set; }
        [Required]
        [Display(Name = "Название операционной системы")]   
        public string NamePsu { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Мощность блока питания в Вт")]
        [Range(typeof(int), "1", "1000000")]
        public int AmountPower { get; set; }
        [Required]
        [Display(Name = "Сертификат блока питания")]
        public string Certificate { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
