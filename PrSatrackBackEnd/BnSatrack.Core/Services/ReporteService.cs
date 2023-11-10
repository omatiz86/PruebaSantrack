using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Repository;
using BnSatrack.Core.Interfaces.Service;

namespace BnSatrack.Core.Services
{
    public class ReporteService : IReportesService
    {
        #region Atributos y Propiedades 
        private readonly IReportesRepository _basicDataRepository;
        #endregion

        #region Constructor
        public ReporteService(IReportesRepository basicDataRepository)
        {
            this._basicDataRepository = basicDataRepository;
        }
        #endregion

        public object ReporteMesaMes()
        {
            var dataReport = this._basicDataRepository.GetReporteMesaMes();
            return dataReport;
        }      
      

        public object ReporteSaldoPromedio()
        {
            var dataReport = this._basicDataRepository.GetReporteSaldoPromedio();
            return dataReport;
        }

        public object ReporteTopClientesPorProducto()
        {
            var dataReport = this._basicDataRepository.GetReporteTopClientesPorProductoo();
            return dataReport;
        }
    }
}
