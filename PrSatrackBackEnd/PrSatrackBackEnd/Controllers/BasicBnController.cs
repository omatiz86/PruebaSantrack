using AutoMapper;
using BnSatrack.Api.DTO;
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
    public class BasicBnController : ControllerBase
    {
        #region Atributos y Propiedades
        private readonly IMapper _mapper;
        private readonly IBasicDataService _basicService;
        #endregion

        #region Constructor
        /// <summary>
        /// Fecha: 1 de Noviembre de 2023
        /// Descripción: 
        /// Autor:  Omar Chacon
        /// </summary> 
        /// <param name="service">Interface del servivio de Marca</param>
        /// <param name="mapper">Interface del servciio de Mapper</param>

        public BasicBnController(IBasicDataService service, IMapper mapper)
        {
            _basicService = service;
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
        [HttpGet]
        [Route("ObtenerUbicacion")]
        [SwaggerOperation(Summary = "Ubicacion")]
        public ResponseDto ObtenerUbicacion()
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Consulta ciudades y paises generada correctamente."
            };
            try
            {
                var list = _basicService.ObtenerUbicacion();
                //var result = _mapper.Map<UbicacionDto>(list);
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
        [Route("ObtenerTipoProducto")]
        [SwaggerOperation(Summary = "Tipo Producto")]
        public ResponseDto ObtenerTipoProducto()
        {
            ResponseDto response = new ResponseDto
            {
                Estado = true,
                Codigo = HttpStatusCode.OK.GetHashCode(),
                mensaje = "Consulta producto generada correctamente."
            };
            try
            {
                var list = _basicService.ObtenerTipoProducto();
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
