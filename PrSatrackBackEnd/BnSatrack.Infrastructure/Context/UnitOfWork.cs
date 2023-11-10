using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using BnSatrack.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace BnSatrack.Infrastructure.Context
{
    /// <summary>
    /// Fecha: 1 de Noviembre de 2023
    /// Descripción: Clase que permite operaciones unificar y simplificar los llamados a repositorios.
    /// Autor: Omar Chacon
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFContext _dbContext;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Constructor de la clase Clase UnitOfWork
        /// Autor: Omar Chacon
        /// </summary>
        public UnitOfWork(IConfiguration configuration, EFContext dbContext)
        {
            _dbContext = dbContext;
            this._configuration = configuration;
        }

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Interface que utiliza unitOfWork para volver genericos los llamados a repositorios.
        /// Autor: Omar Chacon
        /// </summary>
        public IBaseRepository<T> BaseRepository<T>() where T : BaseEntity
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Interface que utiliza unitOfWork para guardar los cambios en la base de datos.
        /// Autor: Omar Chacon
        /// </summary>
        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Interface que utiliza unitOfWork para guardar los cambios en la base de datos.
        /// Autor: Omar Chacon
        /// </summary>
        public IClienteRepository ClienteRepository()
        {
            return new ClienteRepository(_dbContext);            
        }

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Interface que utiliza unitOfWork para guardar los cambios en la base de datos.
        /// Autor: Omar Chacon
        /// </summary>
        public IGestionBnRepository GestionBnRepository()
        {
            return new GestionBnRepository(this._configuration, _dbContext);            
        }


    }
}
