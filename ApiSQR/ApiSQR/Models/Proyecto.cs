using System;
using System.Collections.Generic;

namespace ApiSQR.Models
{
    public partial class Proyecto
    {
        public int Codproy { get; set; }
        public string? Nomproy { get; set; }
        public byte[]? Archivoproy { get; set; }
        public int Idest { get; set; }
        public int Idadmin { get; set; }

        public virtual Admin IdadminNavigation { get; set; } = null!;
        public virtual Estudiante IdestNavigation { get; set; } = null!;
    }
}
