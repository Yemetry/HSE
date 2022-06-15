using System;
using System.Collections.Generic;

#nullable disable

namespace Practica_new.Models
{
    public partial class SpravAmount
    {
        public SpravAmount()
        {
            Rams = new HashSet<Ram>();
        }

        public int Id { get; set; }
        public int AmountMemoryRam { get; set; }

        public virtual ICollection<Ram> Rams { get; set; }
    }
}
