using SICPMonolithic.Models;

namespace SICPMonolithic.Dtos
{
    public class BienProcedimientoAlta
    {
        //public int? BienId { get; set; }
        public string? NombreReferencial { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? NumeroGuia { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? ProcedimientoTipoId { get; set; }
        public int? CausalId { get; set; }

        public string? Denominacion { get; set; }
        public string? CodigoSBN { get; set; }
        public string? Marca { get; set; }
        public string? Modelo { get; set; }
        public string? Serie { get; set; }
        public string? Color { get; set; }
        public string? Observacion { get; set; }
        public int? ProcedimientoId { get; set; }
        public int? CategoriaId { get; set; }
    }
}
