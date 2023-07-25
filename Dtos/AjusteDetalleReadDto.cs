using SICPMonolithic.Models;

namespace SICPMonolithic.Dtos
{
    public class AjusteDetalleReadDto
    {
        public int Id { get; set; }
        public int? CantidadAfectada { get; set; }
        public string? InventarioString { get; set; }
        public int? InventarioId { get; set; }
        public string? AreaDestinoString { get; set; }
        public int? AreaDestinoId { get; set; }
        public string? AreaOrigenString { get; set; }
        public int? AreaOrigenId { get; set; }
        public string? AjusteString { get; set; }
        public int? AjusteId { get; set; }

    }
}
