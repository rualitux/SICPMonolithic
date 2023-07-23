namespace SICPMonolithic.Models
{
    public class ProcedimientoInventario
    {
        public int Id { get; set; }
        public bool EsActual { get; set; }
        public int InventarioId { get; set; }
        public Inventario Inventario { get; set; }
        public int ProcedimientoId { get; set; }
        public Procedimiento? Procedimiento { get; set; }
    }
}
