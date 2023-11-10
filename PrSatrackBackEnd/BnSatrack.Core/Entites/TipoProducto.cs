using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Entites
{
    public class TipoProducto
    {
        public TipoProducto()
        {
            Productos = new HashSet<Producto>();
        }

        public int IdTipoProducto { get; set; }
        public string? Descripcion { get; set; }
        public string? Activo { get; set; }

        public virtual ICollection<Producto> Productos { get; set; }
    }
}
