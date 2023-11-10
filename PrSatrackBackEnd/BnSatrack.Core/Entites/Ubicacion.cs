using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Entites
{
    public  class Ubicacion
    {
        public Ubicacion()
        {
            Clientes = new HashSet<Cliente>();
        }

        public int? IdUbicacion { get; set; }
        public string? CodDivipola { get; set; } = null!;
        public string? Descripcion { get; set; }
        public string? Tipo { get; set; }
        public string? IdPapa { get; set; }
        public string? IdHijo { get; set; }
        public string? Activo { get; set; }
        public string? Indicativo { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }

    }
}
