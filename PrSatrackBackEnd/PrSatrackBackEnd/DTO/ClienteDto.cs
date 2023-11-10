using BnSatrack.Core.Entites;

namespace BnSatrack.Api.DTO
{
    public class ClienteDto
    {

        /// <summary>
        /// Identificador del Cliente
        /// </summary>
        /// 
        //public ClienteDto()
        //{
        //    Productos = new HashSet<ProductoDto>();
        //}

        //public int? Idcliente { get; set; }
        public string? Nombre { get; set; }
        public string? TipoDocumento { get; set; }
        public int Documento { get; set; }
        public int? Nit { get; set; }
        public string? TipoCliente { get; set; }
        public string? TelefonoContacto { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? Direccion { get; set; }
        public string? IdUbicacion { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Genero { get; set; }
        public string? Notas { get; set; }        
        //public virtual ICollection<ProductoDto> Productos { get; set; }


    }
}
