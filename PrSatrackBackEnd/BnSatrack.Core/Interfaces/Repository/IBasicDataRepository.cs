using BnSatrack.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Interfaces.Repository
{
    public interface IBasicDataRepository
    {
        public List<Ubicacion> GetUbicacion();

        public List<TipoProducto> GetProductos();

    }
}
