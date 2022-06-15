using System;
using System.Collections.Generic;

#nullable disable

namespace Practica_new.Models
{
    public partial class Build
    {
        public Build()
        {
            SaveBuilds = new HashSet<SaveBuild>();
        }

        public int IdBuild { get; set; }
        public int? IdCpu { get; set; }
        public int? IdGpu { get; set; }
        public int? IdRam { get; set; }
        public int? IdDisk { get; set; }
        public int? IdMotherboard { get; set; }
        public int? IdPsu { get; set; }
        public int? IdCpucool { get; set; }
        public int? IdCarcass { get; set; }
        public int? IdOs { get; set; }

        public virtual Carcass IdCarcassNavigation { get; set; }
        public virtual Cpu IdCpuNavigation { get; set; }
        public virtual Cpucool IdCpucoolNavigation { get; set; }
        public virtual Disk IdDiskNavigation { get; set; }
        public virtual Gpu IdGpuNavigation { get; set; }
        public virtual Motherboard IdMotherboardNavigation { get; set; }
        public virtual O IdOsNavigation { get; set; }
        public virtual Psu IdPsuNavigation { get; set; }
        public virtual Ram IdRamNavigation { get; set; }
        public virtual ICollection<SaveBuild> SaveBuilds { get; set; }
    }
}
