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

    [Route("api/[controller]")]
    [ApiController]
    public class ClienteBnController : ControllerBase
    {
        #region Atributos y Propiedades
        private readonly IMapper _mapper;
        private readonly IClienteService _clienteService;
        #endregion

        #region Constructor
        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary> 
        /// <param name="service">Interface del servivio de Marca</param>
        /// <param name="mapper">Interface del servciio de Mapper</param>

        public ClienteBnController(IClienteService service, IMapper mapper)
        {
            _clienteService = service;
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
        [Route("ObtenerInformacionCliente")]
        [SwaggerOperation(Summary = "obtener lista de Clientes")]
        public ResponseDto ObtenerInformacionCliente()
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Consulta de Cliente generada correctamente."
            };
            try
            {
                var list = _clienteService.ObtenerInformacion();                
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
        [HttpPost]
        [Route("CrearCliente")]
        [SwaggerOperation(Summary = "Crear Cliente")]
        public ResponseDto CrearCliente([FromBody] ClienteDto cliente)
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Creacion correctamente."
            };
            try
            {
                var list = _clienteService.CrearCliente(_mapper.Map<Cliente>(cliente));
                response.data = list;
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message == "Infracción de la restricción UNIQUE KEY 'UNQ_documento_identidad'. No se puede insertar una clave duplicada en el objeto 'dbo.Clientes'. El valor de la clave duplicada es ("+ cliente.Documento + ").")
                {
                    response.Estado = false;
                    response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                    response.mensaje = "Cliente ya registrado";
                }    else
                {
                    response.Estado = false;
                    response.Codigo = HttpStatusCode.InternalServerError.GetHashCode();
                    response.mensaje = ex.Message;
                }
            }

            return response;
        }
        #endregion

    }
}
