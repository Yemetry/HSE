using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Gpu
    {
        public Gpu()
        {
            Builds = new HashSet<Build>();
        }
        [Required]
        [Display(Name = "ID видеокарты")]
        public int IdGpu { get; set; }
        [Required]
        [Display(Name = "Название видеокарты")]
        public string NameGpu { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Графический процессор видеокарты")]
        public string GraphicsProc { get; set; }
        [Required]
        [Display(Name = "Количество памяти видеокарты в ГБ")]
        [Range(typeof(int), "1", "50")]
        public int AmountMemory { get; set; }
        [Required]
        [Display(Name = "Тип памяти видеокарты")]
        public string TypeMemory { get; set; }
        [Required]
        [Display(Name = "Энергопотребление видеокарты в Вт")]
        [Range(typeof(int), "1", "500")]
        public int EnergyConsumptionGpu { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
