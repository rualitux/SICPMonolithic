namespace SICPMonolithic.Dtos
{
    public class AjusteBajaDto
    {
        public string? Justificacion { get; set; }
        public DateTime? FechaRegistro { get; set; }
        //public int? AjusteTipoId { get; set; }
        public int? CantidadAfectada { get; set; }
        public int? InventarioId { get; set; }
        //public int? AreaDestinoId { get; set; }
        //public int? AreaOrigenId { get; set; }
        public int? AjusteId { get; set; }
        public string? NombreReferencial { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? NumeroGuia { get; set; }
        public DateTime? FechaDocumento { get; set; }
        public int? ProcedimientoTipoId { get; set; }
        public int? CausalId { get; set; }
        //inventario
        public int? Cantidad { get; set; }
        public int? BienPatrimonialId { get; set; }
        public int? AnexoTipoId { get; set; }
        public int? EstadoCondicionId { get; set; }
        //public int? EstadoBienId { get; set; }
        public int? AreaId { get; set; }
        public int? ProcedimientoId { get; set; }
    }
}
