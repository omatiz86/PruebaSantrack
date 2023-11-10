using BnSatrack.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Interfaces.Service
{
    public interface IBasicDataService
    {
        public List<Ubicacion> ObtenerUbicacion();
        public List<TipoProducto> ObtenerTipoProducto();

    }
}
