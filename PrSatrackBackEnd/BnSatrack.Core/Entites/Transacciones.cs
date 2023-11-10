using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Entites
{
    public class Transacciones : BaseEntity
    {
        /// <summary>
        /// Identificador del Transacciones
        /// </summary>
        public Transacciones()
        {
            Productos = new HashSet<Producto>();
        }

        public int Idtransaccion { get; set; }
        public int Idproducto { get; set; }
        public string? Documento { get; set; }
        public string? TipoTransaccion { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? Fecha { get; set; }        

        public virtual ICollection<Producto> Productos { get; set; }

    }
}
