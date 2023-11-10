using BnSatrack.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BnSatrack.Core.Interfaces.Service
{
    public interface IGestionBnService
    {
        object AgregarTrasaccion(Transacciones data);

        object CancelarCDT(string idCdt);

        object ObtenerProductosxCliente(string documento);


    }
}
