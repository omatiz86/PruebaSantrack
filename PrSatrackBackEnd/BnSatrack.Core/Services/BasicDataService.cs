using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using BnSatrack.Core.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Services
{
    public  class BasicDataService  : IBasicDataService
    {
        private readonly IBasicDataRepository _basicDataRepository;

        public BasicDataService(IBasicDataRepository basicDataRepository) {
            this._basicDataRepository = basicDataRepository;
        }

        public List<TipoProducto> ObtenerTipoProducto()
        {
            var dataReport = this._basicDataRepository.GetProductos();
            return dataReport;
        }

        public List<Ubicacion> ObtenerUbicacion()
        {
            var dataReport = this._basicDataRepository.GetUbicacion();
            return dataReport;
        }
       

        
    }
}
