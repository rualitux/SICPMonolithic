using SICPMonolithic.Models;

namespace SICPMonolithic.Dtos
{
    public class AjusteReadDto
    {
        public int Id { get; set; }
        public string? Justificacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? AjusteTipoId { get; set; }

        public string? AjusteTipoString { get; set; }
    }
}
