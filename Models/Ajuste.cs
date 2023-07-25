namespace SICPMonolithic.Models
{
    public class Ajuste
    {
        public int Id { get; set; }
        public string? Justificacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? AjusteTipoId { get; set; }
        public Enumerado? AjusteTipo { get; set; }
    }
}
