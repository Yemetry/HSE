using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Carcass
    {
        public Carcass()
        {
            Builds = new HashSet<Build>();
        }
        [Required]
        [Display(Name = "ID корпуса")]
        public int IdCarcass { get; set; }
        [Required]
        [Display(Name = "Название корпуса")]
        public string NameCarcass { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Форм-фактор материнской платы")]
        public string MotherboardFormFactor { get; set; }
        [Required]
        [Display(Name = "Количество USB портов")]
        [Range(typeof(int), "1", "10")]
        public int NumberUsbOutputs { get; set; }
        [Required]
        [Display(Name = "Количество аудио портов")]
        [Range(typeof(int), "1", "5")]
        public int NumberAudioOutputs { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
