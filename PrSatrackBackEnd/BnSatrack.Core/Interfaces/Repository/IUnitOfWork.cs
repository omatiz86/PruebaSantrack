using BnSatrack.Core.Entites;

namespace BnSatrack.Core.Interfaces.Repository
{
    public interface IUnitOfWork
    {

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Interface de la base de operaciones en base de datos.
        /// Autor:  Omar Chacon
        /// </summary>
        IBaseRepository<T> BaseRepository<T>() where T : BaseEntity;


        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Interface de la base de operaciones en base de datos.
        /// Autor:  Omar Chacon
        /// </summary>
        int SaveChanges();

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Interface que permite acceso  a metodos personalizados de persistencia para Clientes.
        /// Autor:  Omar Chacon        
        /// </summary>
        IClienteRepository ClienteRepository();

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Interface que permite acceso  a metodos personalizados de persistencia para Clientes.
        /// Autor:  Omar Chacon        
        /// </summary>
        IGestionBnRepository GestionBnRepository();
    }
}
