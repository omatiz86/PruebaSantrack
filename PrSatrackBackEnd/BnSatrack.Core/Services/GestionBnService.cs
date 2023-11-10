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
    public class GestionBnService : BaseService, IGestionBnService
    {

        #region Atributos y Propiedades 
        private readonly IGestionBnRepository _gestionRepository;
        #endregion

        #region Constructor
        public GestionBnService(IGestionBnRepository gestionRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this._gestionRepository = gestionRepository;
        }
        #endregion

        #region Métodos y Funciones

        public object AgregarTrasaccion(Transacciones data)
        {
            var repository = UnitOfWork.GestionBnRepository();
            var respuestaUsuario = repository.Add(data);
            UnitOfWork.SaveChanges();
            repository.UpdateActualizarSaldo(data.Documento);

            return respuestaUsuario;
        }

        public object CancelarCDT(string idCdt)
        {
            var dataReport = this._gestionRepository.GetCancelarCDT(idCdt);
            return dataReport;
        }

        public object ObtenerProductosxCliente(string documento)
        {
            var dataReport = this._gestionRepository.GetProductosxCliente(documento);
            return dataReport;
        }

        #endregion
    }
}
