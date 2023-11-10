using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using BnSatrack.Core.Interfaces.Service;



namespace BnSatrack.Core.Services
{
    public class ClienteService : BaseService, IClienteService
    {
        #region Atributos y Propiedades                
        #endregion

        #region Constructor
        public ClienteService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            
        }    

        #endregion

        public object CrearCliente(Cliente cliente)
        {
            var repository = UnitOfWork.ClienteRepository();
            var respuestaUsuario = repository.AddCliente(cliente);            
            return respuestaUsuario;
        }      

        public object ObtenerInformacion()
        {
            var repository = UnitOfWork.ClienteRepository();
            var respuesta = repository.DetalleCliente();         
            return respuesta;
        }
    }
}
