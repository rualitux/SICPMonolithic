using SICPMonolithic.Models;

namespace SICPMonolithic.Dtos
{
    public class AjusteDetalleCreateDto
    {
        public int Id { get; set; }
        public int? CantidadAfectada { get; set; }
        public int? InventarioId { get; set; }
        public int? AreaDestinoId { get; set; }
        public int? AreaOrigenId { get; set; }
        public int? AjusteId { get; set; }
    }
}
