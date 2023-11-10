using AutoMapper;
using BnSatrack.Api.DTO;
using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Service;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace BnSatrack.Api.Controllers
{
    /// <summary>
    /// Fecha: 1 de Noviembre de 2023
    /// Descripción: 
    /// Autor:  Omar Chacon
    /// </summary> 
    /// 
    [Route("api/[controller]")]
    [ApiController]
    public class ReportBnController : ControllerBase
    {
        #region Atributos y Propiedades
        private readonly IMapper _mapper;
        private readonly IReportesService _reporteService;
        #endregion

        #region Constructor
        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary> 
        /// <param name="service">Interface del servivio de Marca</param>
        /// <param name="mapper">Interface del servciio de Mapper</param>

        public ReportBnController(IReportesService service, IMapper mapper)
        {
            _reporteService = service;
            _mapper = mapper;
        }
        #endregion


        #region Métodos y Funciones

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary>        
        /// <returns></returns>
        [HttpGet]
        [Route("ProyeccionMesaMes")]
        [SwaggerOperation(Summary = "Consulta Proyeccion Mes a Mes")]
        public ResponseDto ReporteClienteProducto()
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Reporte Generado."
            };
            try
            {
                var list = _reporteService.ReporteMesaMes();
                response.data = list;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                response.mensaje = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary>        
        /// <returns></returns>
        [HttpGet]
        [Route("MercadeoSaldoPromedio")]
        [SwaggerOperation(Summary = "Consulta de Mercadeo Saldo Promedio")]
        public ResponseDto MercadeoSaldoPromedio()
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Reporte Generado."
            };
            try
            {
                var list = _reporteService.ReporteSaldoPromedio();
                response.data = list;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                response.mensaje = ex.Message;
            }

            return response;
        }


        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary>        
        /// <returns></returns>
        [HttpGet]
        [Route("TopClientesPorProducto")]
        [SwaggerOperation(Summary = "Top 10 de los Clientes Por Producto")]
        public ResponseDto TopClientesPorProducto()
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Reporte Generado."
            };
            try
            {
                var list = _reporteService.ReporteTopClientesPorProducto();
                response.data = list;
            }
            catch (Exception ex)
            {
                response.Estado = false;
                response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                response.mensaje = ex.Message;
            }

            return response;
        }


        #endregion

    }
}
