using BnSatrack.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Interfaces.Repository
{
    public interface IReportesRepository
    {
        public List<MesaMes> GetReporteMesaMes();

        public List<SaldoPromedio> GetReporteSaldoPromedio();

        public List<TopClientes> GetReporteTopClientesPorProductoo();

        
    }
}
