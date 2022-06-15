using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Cpucool
    {
        public Cpucool()
        {
            Builds = new HashSet<Build>();
        }
        [Required]
        [Display(Name = "ID охлаждение процессора")]
        public int IdCpucool { get; set; }
        [Required]
        [Display(Name = "Название охлаждение процессора")]
        public string NameCpucool { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Совместимость сокетов")]
        public string CompatibleSockets { get; set; }
        [Required]
        [Display(Name = "Тепловой пакет в ваттах")]
        [Range(typeof(int), "1", "500")]
        public int Tdp { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
