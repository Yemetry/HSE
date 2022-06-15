using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Practica_new.Models
{
    public partial class Motherboard
    {
        public Motherboard()
        {
            Builds = new HashSet<Build>();
        }
        [Required]
        [Display(Name = "Id материнской платы")]
        public int IdMotherboard { get; set; }
        [Required]
        [Display(Name = "Название материнской платы")]
        public string NameMotherboard { get; set; }
        [Required]
        [Display(Name = "Цена")]
        [Range(typeof(decimal), "1", "1000000")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Бренд")]
        public string Brand { get; set; }
        [Required]
        [Display(Name = "Сокет материнской платы")]
        public string SocketProcessor { get; set; }
        [Required]
        [Display(Name = "Количество слотов оперативной памяти в материнской плате ")]
        [Range(typeof(int), "1", "8")]
        public int NumberSlotsRam { get; set; }
        [Required]
        [Display(Name = "Количество слотов M2 SSD в материнской плате ")]
        [Range(typeof(int), "1", "8")]
        public int NumberM2storageSlots { get; set; }
        [Required]
        [Display(Name = "Чипсет материнской платы")]
        public string Chipset { get; set; }
        [Required]
        [Display(Name = "Форм-фактор материнской платы")]
        public string FormFactor { get; set; }

        public virtual ICollection<Build> Builds { get; set; }
    }
}
