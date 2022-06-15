using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Hdd
    {
        public Hdd()
        {
            Disks = new HashSet<Disk>();
        }
        [Required]
        [Display(Name = "Id HDD")]
        public int IdHdd { get; set; }
        [Required]
        [Display(Name = "Название HDD")]
        public string NameHdd { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Скорость вращение диска об/мин")]
        [Range(typeof(decimal), "1", "100000")]
        public int SpeedDisk { get; set; }
        [Required]
        [Display(Name = "Количество памяти HDD в ГБ")]
        [Range(typeof(decimal), "1", "200000")]
        public int SizeMemoryHdd { get; set; }

        public virtual ICollection<Disk> Disks { get; set; }
    }
}
