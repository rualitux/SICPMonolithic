namespace SICPMonolithic.Dtos
{
    public class AjusteMovimientoDto
    {
        public string? Justificacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? AjusteTipoId { get; set; }
        public int? CantidadAfectada { get; set; }
        public int? InventarioId { get; set; }
        public int? AreaDestinoId { get; set; }
        public int? AreaOrigenId { get; set; }
        public int? AjusteId { get; set; }
    }
}
