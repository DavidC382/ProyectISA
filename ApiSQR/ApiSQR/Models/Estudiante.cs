using System;
using System.Collections.Generic;

namespace ApiSQR.Models
{
    public partial class Estudiante
    {
        public Estudiante()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int Idest { get; set; }
        public int? Codest { get; set; }
        public int? Semest { get; set; }
        public string? Nomest { get; set; }
        public string? Apeest { get; set; }
        public string? Paswest { get; set; }

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
