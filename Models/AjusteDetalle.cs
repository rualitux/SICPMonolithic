namespace SICPMonolithic.Models
{
    public class AjusteDetalle
    {
        public int Id { get; set; }
        public int? CantidadAfectada { get; set; }
        public int? InventarioId { get; set; }
        public Inventario? Inventario { get; set; }
        public int? AreaDestinoId { get; set; }
        public Area? AreaDestino { get; set; }
        public int? AreaOrigenId { get; set; }
        public Area? AreaOrigen { get; set; }
        public int? AjusteId { get; set; }
        public Ajuste? Ajuste { get; set; }
    }
}
