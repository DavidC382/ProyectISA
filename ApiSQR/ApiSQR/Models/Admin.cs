using System;
using System.Collections.Generic;

namespace ApiSQR.Models
{
    public partial class Admin
    {
        public Admin()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Idadmin { get; set; }
        public string? Nomadmin { get; set; }
        public string? Apeadmin { get; set; }
        public string? Paswadim { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
