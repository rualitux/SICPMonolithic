namespace SICPMonolithic.Dtos
{
    public class AreaCreateDto
    {
        public int? Id { get; set; }
        public string? Nombre { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? SedeId { get; set; }
        public int? DependenciaId { get; set; }
        public int? EstadoAreaId { get; set; }
    }
}
