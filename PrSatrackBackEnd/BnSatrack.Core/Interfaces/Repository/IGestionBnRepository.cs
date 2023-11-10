using BnSatrack.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Interfaces.Repository
{
    public interface IGestionBnRepository : IBaseRepository<Transacciones>
    {

        object UpdateActualizarSaldo(string documento);
        object GetCancelarCDT(string idCdt);

        object GetProductosxCliente(string documento);


    }
}
