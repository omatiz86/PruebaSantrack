using AutoMapper;
using BnSatrack.Api.DTO;
using BnSatrack.Core.Entites;
using BnSatrack.Core.Interfaces.Service;
using Microsoft.AspNetCore.Http;
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

    [Route("api/[controller]")]
    [ApiController]
    public class ProcesosBancoController : ControllerBase
    {

        #region Atributos y Propiedades
        private readonly IMapper _mapper;
        private readonly IGestionBnService _gestionService;
        #endregion

        #region Constructor
        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary> 
        /// <param name="service">Interface del servivio de Marca</param>
        /// <param name="mapper">Interface del servciio de Mapper</param>

        public ProcesosBancoController(IGestionBnService service, IMapper mapper)
        {
            _gestionService = service;
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
        /// 
        [HttpPost]
        [Route("InsertarTransaccion")]
        [SwaggerOperation(Summary = "Insertar Transaccion")]
        public ResponseDto InsertarTransaccion([FromBody] TransaccionDto data)
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Consulta cidades y paises generada correctamente."
            };
            try
            {
                var list = _gestionService.AgregarTrasaccion(_mapper.Map<Transacciones>(data));
                var result = _mapper.Map<TransaccionDto>(list);
                response.data = result;
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
        /// 
        [HttpGet]
        [Route("CancelarCDT")]
        [SwaggerOperation(Summary = "Cancelar CDT")]
        public ResponseDto CancelarCDT(string idCdt)
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Consulta producto generada correctamente."
            };
            try
            {
                var list = _gestionService.CancelarCDT(idCdt);
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
        /// 
        [HttpGet]
        [Route("GetProductosxCliente")]
        [SwaggerOperation(Summary = "consulta de Productos x Cliente")]
        public ResponseDto GetProductosxCliente(string documento)
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Consulta producto generada correctamente."
            };
            try
            {
                var list = _gestionService.ObtenerProductosxCliente(documento);
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
