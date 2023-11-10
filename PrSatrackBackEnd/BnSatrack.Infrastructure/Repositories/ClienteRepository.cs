using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using BnSatrack.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace BnSatrack.Infrastructure.Repositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        #region Atributos y Propiedades
        private readonly EFContext context;
        #endregion Atributos y Propiedades

        #region Constructor
        public ClienteRepository(EFContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
        }
        #endregion Constructor


        #region Métodos y Funciones

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Método que lista los correos de un usuario
        /// Autor: Omar Chacon
        /// </summary>
        /// <param name="Correo"></param>
        /// <returns></returns>
        public List<Cliente> DetalleCliente()
        {            
            var consulta = (from c in context.Clientes                            
                            select c
                            ).ToList();
         
            return consulta;
        }

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: Método que inserta data de cliente
        /// Autor: Omar Chacon
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public object AddCliente(Cliente cliente)
        {
            //var result = "Estado Repository para insercion de data Cliente";
            var result = this.context.Clientes.Add(cliente);
            this.context.SaveChanges();            
            return result;
        }

      
        #endregion
    }
}
