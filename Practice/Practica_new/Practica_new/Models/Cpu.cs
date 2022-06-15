using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Cpu
    {
        public Cpu()
        {
            Builds = new HashSet<Build>();
        }
        [Required]
        [Display(Name = "ID процессора")]
        public int IdCpu { get; set; }
        [Required]
        [Display(Name = "Название процессора")]
        public string NameCpu { get; set; }
        [Required]
        [Display(Name = "Сокет процессора")]
        public string Soket { get; set; }
        [Required]
        [Display(Name = "Серия процессора")]
        public string SeriesCpu { get; set; }
        [Required]
        [Display(Name = "Количество ядер")]
        [Range(typeof(int), "1", "24")]
        public int CountCore { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Тепловой пакет в ваттах")]
        [Range(typeof(int), "1", "500")]
        public int Tdp { get; set; }
        [Required]
        [Display(Name = "Энергопотребление процессора в Вт")]
        [Range(typeof(int), "1", "500")]
        public int EnergyConsumptionCpu { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
