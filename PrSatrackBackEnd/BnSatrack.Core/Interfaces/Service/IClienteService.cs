using BnSatrack.Core.Entites;

namespace BnSatrack.Core.Interfaces.Service
{
    public interface IClienteService
    {
        #region Métodos y Funciones

        /// <summary>
        /// Fecha: 01 de Noviembre de 2023
        /// Descripción: Interface que permite el llamado al metodo de  Crear cliente
        /// Autor: Omar Chacon 
        /// </summary>                
        /// <param name="cliente"> Enidad a la que se le aplica la opareción </param>
        /// <returns>Retonra la información del cliente creado </returns>
        object ObtenerInformacion();

        /// <summary>
        /// Fecha: 01 de Noviembre de 2023
        /// Descripción: Interface que permite el llamado al metodo de  Crear cliente
        /// Autor: Omar Chacon 
        /// </summary>                
        /// <param name="cliente"> Enidad a la que se le aplica la opareción </param>
        /// <returns>Retonra la información del cliente creado </returns>
        object CrearCliente(Cliente cliente);

        #endregion
    }
}
