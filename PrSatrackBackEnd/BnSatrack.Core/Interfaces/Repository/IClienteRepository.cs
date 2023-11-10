using BnSatrack.Core.Entites;

namespace BnSatrack.Core.Interfaces.Repository
{
    public interface IClienteRepository //: IBaseRepository<Cliente>
    {
        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary>        
        /// <returns></returns>        

        List<Cliente> DetalleCliente();

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary>        
        /// <returns></returns>        
        object AddCliente(Cliente cliente);



    }
}
