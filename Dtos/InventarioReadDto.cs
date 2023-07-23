using SICPMonolithic.Models;

namespace SICPMonolithic.Dtos
{
    public class InventarioReadDto
    {
        public int Id { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? BienPatrimonialId { get; set; }
        public string? BienPatrimonialString { get; set; }
        public int? AnexoTipoId { get; set; }
        public string? AnexoTipoString { get; set; }
        public int? EstadoCondicionId { get; set; }
        public string? EstadoCondicionString { get; set; }
        public int? EstadoBienId { get; set; }
        public string? EstadoBienString { get; set; }
        public int? AreaId { get; set; }
        public string? AreaString { get; set; }
        public int? ProcedimientoId { get; set; }
        public string? ProcedimientoString { get; set; }

    }
}
