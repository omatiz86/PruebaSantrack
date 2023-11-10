using BnSatrack.Core.Entites;

namespace BnSatrack.Core.Interfaces.Service
{
    public interface IReportesService
    {
        #region Métodos y Funciones

     
        /// <summary>
        /// Fecha: 01 de Noviembre de 2023
        /// Descripción: Interface que permite el llamado al metodo de  Crear cliente
        /// Autor: Omar Chacon 
        /// </summary>                        
        /// <returns>Retonra la información de productos </returns>
        object ReporteMesaMes();

        /// <summary>
        /// Fecha: 01 de Noviembre de 2023
        /// Descripción: Interface que permite el llamado al metodo de  Crear cliente
        /// Autor: Omar Chacon 
        /// </summary>                        
        /// <returns>Retonra la información de productos </returns>
        object ReporteSaldoPromedio();

        /// <summary>
        /// Fecha: 01 de Noviembre de 2023
        /// Descripción: Interface que permite el llamado al metodo de  Crear cliente
        /// Autor: Omar Chacon 
        /// </summary>                        
        /// <returns>Retonra la información de productos </returns>
        object ReporteTopClientesPorProducto();

        #endregion



    }
}
