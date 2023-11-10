using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BnSatrack.Core.Entites
{
    /// <summary>
    /// Identificador del Producto
    /// </summary>
    public class Producto
    {
        public int Idproducto { get; set; }
        public int Idcliente { get; set; }
        public int? Idtransaccion { get; set; }
        public int? TipoProducto { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? InteresMensual { get; set; }
        public DateTime? FechaApertura { get; set; }
        public bool Activo { get; set; }


        public virtual Cliente IdclienteNavigation { get; set; } = null!;
        public virtual Transacciones? IdtransaccionNavigation { get; set; }
        public virtual TipoProducto? TipoProductoNavigation { get; set; }


    }
}
