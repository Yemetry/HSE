using System;
using System.Collections.Generic;

#nullable disable

namespace Practica_new.Models
{
    public partial class Disk
    {
        public Disk()
        {
            Builds = new HashSet<Build>();
        }

        public int IdDisk { get; set; }
        public int IdSsd { get; set; }
        public int IdHdd { get; set; }

        public virtual Hdd IdHddNavigation { get; set; }
        public virtual Ssd IdSsdNavigation { get; set; }
        public virtual ICollection<Build> Builds { get; set; }
    }
}
