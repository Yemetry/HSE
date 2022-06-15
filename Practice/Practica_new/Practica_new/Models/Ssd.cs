using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Ssd
    {
        public Ssd()
        {
            Disks = new HashSet<Disk>();
        }
        [Required]
        [Display(Name = "Id SSD")]
        public int IdSsd { get; set; }
        [Required]
        [Display(Name = "Название SSD")]
        public string NameSsd { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Количество памяти SSD")]
        [Range(typeof(decimal), "1", "100000")]
        public int SizeMemorySsd { get; set; }
        [Required]
        [Display(Name = "Скорость записи SSD")]
        [Range(typeof(decimal), "1", "100000")]
        public int SpeedRecord { get; set; }

        public virtual ICollection<Disk> Disks { get; set; }
    }
}
