using System;
using System.Collections.Generic;

#nullable disable

namespace Practica_new.Models
{
    public partial class SaveBuild
    {
        public int IdBuild { get; set; }
        public int UserId { get; set; }
        public int IdSave { get; set; }

        public virtual Build IdBuildNavigation { get; set; }
        public virtual User User { get; set; }
    }
}
