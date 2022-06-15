using System;
using System.Collections.Generic;

#nullable disable

namespace Practica_new.Models
{
    public partial class SpravRam
    {
        public SpravRam()
        {
            Rams = new HashSet<Ram>();
        }

        public int Id { get; set; }
        public string TypeMemoryRam { get; set; }

        public virtual ICollection<Ram> Rams { get; set; }
    }
}
