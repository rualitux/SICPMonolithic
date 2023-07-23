using SICPMonolithic.Models;

namespace SICPMonolithic.Dtos
{
    public class TESTBienProcedimientoAltaDto
    {
        public string? NombreReferencial { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? NumeroGuia { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? ProcedimientoTipoId { get; set; }
        public int? CausalId { get; set; }
        public int? CantidadBienes { get; set; }
        public List<BienPatrimonialCreateDto>? bienPatrimonialCreateDtos { get; set; }
    }
}
