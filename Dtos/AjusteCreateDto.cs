using SICPMonolithic.Models;

namespace SICPMonolithic.Dtos
{
    public class AjusteCreateDto
    {
        public int Id { get; set; }
        public string? Justificacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? AjusteTipoId { get; set; }
    }
}
