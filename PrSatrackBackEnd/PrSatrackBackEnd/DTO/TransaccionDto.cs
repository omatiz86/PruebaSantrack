namespace BnSatrack.Api.DTO
{
    public class TransaccionDto
    {
        
        public int Idproducto { get; set; }
        public string? Documento { get; set; }
        public string? TipoTransaccion { get; set; }
        public decimal? Monto { get; set; }
        public DateTime? Fecha { get; set; }

    }
}
