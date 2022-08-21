using System;
using System.Collections.Generic;

namespace ApiSQR.Models
{
    public partial class Docente
    {
        public int Iddoc { get; set; }
        public int Coddoc { get; set; }
        public string? Nomdoc { get; set; }
        public string? Apedoc { get; set; }
        public string? Roldoc { get; set; }
        public string? Pawdoc { get; set; }
    }
}
