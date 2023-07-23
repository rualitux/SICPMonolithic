namespace SICPMonolithic.Dtos
{
    public class InventarioCreateDto
    {
        public int Id { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? BienPatrimonialId { get; set; }
        public int? AnexoTipoId { get; set; }
        public int? EstadoCondicionId { get; set; }
        public int? EstadoBienId { get; set; }
        public int? AreaId { get; set; }
        public int? ProcedimientoId { get; set; }
    }
}
