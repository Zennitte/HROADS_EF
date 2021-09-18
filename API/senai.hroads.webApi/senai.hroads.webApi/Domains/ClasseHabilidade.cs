using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class ClasseHabilidade
    {
        public short IdClasseHabilidade { get; set; }
        public byte? IdClasse { get; set; }
        public byte? IdHabilidade { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
