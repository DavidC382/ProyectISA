using System;
using System.Collections.Generic;

namespace ApiSQR.Models
{
    public partial class Proydocente
    {
        public int Codproy { get; set; }
        public int Iddoc { get; set; }

        public virtual Proyecto CodproyNavigation { get; set; } = null!;
        public virtual Docente IddocNavigation { get; set; } = null!;
    }
}
