using System;
using System.Collections.Generic;

#nullable disable

namespace Practica_new.Models
{
    public partial class SpravRamModul
    {
        public SpravRamModul()
        {
            Rams = new HashSet<Ram>();
        }

        public int Id { get; set; }
        public int NumbersModulesRam { get; set; }

        public virtual ICollection<Ram> Rams { get; set; }
    }
}
