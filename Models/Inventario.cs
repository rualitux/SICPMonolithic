using SICPMonolithic.Models;
using System.ComponentModel.DataAnnotations;

namespace SICPMonolithic.Models
{
    public class Inventario
    {
        public int Id { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? BienPatrimonialId { get; set; }
        public BienPatrimonial? BienPatrimonial { get; set; }
        public int? AnexoTipoId { get; set; }
        public Enumerado? AnexoTipo { get; set; }
        public int? EstadoCondicionId { get; set; }
        public Enumerado? EstadoCondicion { get; set; }
        public int? EstadoBienId { get; set; }
        public Enumerado? EstadoBien { get; set; }
        public int? AreaId { get; set; }
        public Area? Area { get; set; }
        public int? ProcedimientoId { get; set; }
        public Procedimiento? Procedimiento { get; set; }
    }
}
