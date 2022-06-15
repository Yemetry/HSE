using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Ram
    {
        public Ram()
        {
            Builds = new HashSet<Build>();
        }
        [Required]
        [Display(Name = "Id оперативной памяти")]
        public int IdRam { get; set; }
        [Required]
        [Display(Name = "Название оперативной памяти")]
        public string NameRam { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Количество оперативной памяти в ГБ")]
        public int AmountMemoryRam { get; set; }
        [Required]
        [Display(Name = "Тип оперативной памяти")]
        public int TypeMemoryRam { get; set; }
        [Required]
        [Display(Name = "Количество модулей оперативной памяти в комплекте")]
        public int NumbersModulesRam { get; set; }
        [Required]
        [Display(Name = "Количество оперативной памяти в ГБ")]
        public virtual SpravAmount AmountMemoryRamNavigation { get; set; }
        [Required]
        [Display(Name = "Количество модулей оперативной памяти в комплекте")]
        public virtual SpravRamModul NumbersModulesRamNavigation { get; set; }
         [Required]
        [Display(Name = "Тип оперативной памяти")]
        public virtual SpravRam TypeMemoryRamNavigation { get; set; }
        public virtual ICollection<Build> Builds { get; set; }
    }
}
