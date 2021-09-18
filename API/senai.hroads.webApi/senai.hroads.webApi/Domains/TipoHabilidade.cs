using System;
using System.Collections.Generic;

#nullable disable

namespace senai.hroads.webApi.Domains
{
    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public byte IdTipoHabilidade { get; set; }
        public string NomeTipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
