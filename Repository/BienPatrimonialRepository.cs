using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SICPMonolithic.Data;
using SICPMonolithic.Dtos;
using SICPMonolithic.Interfaces;
using SICPMonolithic.Models;

namespace SICPMonolithic.Repository
{
    public class BienPatrimonialRepository : IBienPatrimonialRepository
    {
        private readonly AppDbContext _context;

        public BienPatrimonialRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool BienExists(int bienPatrimonialId)
        {
            return _context.BienesPatrimoniales.Any(p => p.Id == bienPatrimonialId);
        }


        public void CreateBien(BienPatrimonial bien)
        {
            if (bien == null)
            {
                throw new ArgumentNullException(nameof(bien));
            }          
            _context.BienesPatrimoniales.Add(bien);
        }

        public IDbContextTransaction CrearTransaccion()
        {
            
            var dbContextTransaction = _context.Database.BeginTransaction();
            return dbContextTransaction;

        }
        //Ignorar x mientras ;P
        public void CreateProcedimiento(Procedimiento procedimiento)
        {

            if (procedimiento == null)
            {
                throw new ArgumentNullException(nameof(procedimiento));
            }
            _context.Procedimientos.Add(procedimiento);
        }

        public void UpdateBien(BienPatrimonial bien)
        {
            _context.Update(bien);
        }

        public void CreateInventario(Inventario inventario)
        {
            if (inventario == null)
            {
                throw new ArgumentNullException(nameof(inventario));
            }            
            _context.Inventarios.Add(inventario);
        }

        public IEnumerable<BienPatrimonial> GetAllBienes()
        {
            //return _context.BienesPatrimoniales.ToList();
            var lista = _context.BienesPatrimoniales
          .Include(a => a.Categoria)
          .ToList();
            return lista;
        }

        public IEnumerable<Inventario> GetAllInventarios()
        {
            var lista = _context.Inventarios
          .Include(a => a.AnexoTipo)
          .Include(a => a.EstadoCondicion)
          .Include(a => a.EstadoBien)
          .Include(a => a.Area)
          .Include(a => a.BienPatrimonial)
          .Include(a => a.Procedimiento)
          .ToList();
             return lista;

        }
        public void UpdateInventario(Inventario inventario)
        {       
            _context.Update(inventario);
        }


        public IEnumerable<ProcedimientoInventario> GetAllProcedimientoBienes()
        {
            return _context.ProcedimientoBiens.ToList();

        }

       

      

        public BienPatrimonial GetBienById(int id)
        {
            //return _context.BienesPatrimoniales.FirstOrDefault(p => p.Id == id);
            var item =  _context.BienesPatrimoniales
              .Include(p => p.Categoria)
              .FirstOrDefault(p => p.Id == id);
            return item;

        }

        public IEnumerable<ProcedimientoInventario> GetBienesByProcedimiento(int procedimientoId)
        {
            var retornito = _context.ProcedimientoBiens
               .Where(c => c.ProcedimientoId == procedimientoId);
               //.OrderBy(c => c.Procedimiento.ProcedimientoTipoString);
            return retornito;
        }

        public IEnumerable<BienPatrimonial> GetBienesForEnumerados(int enumeradoId)
        {
            var retornito = _context.BienesPatrimoniales
                .Where(c => c.CategoriaId == enumeradoId)
                .OrderBy(c => c.Categoria.Valor);
            return retornito;
        }



        public Inventario GetInventarioById(int inventarioId)
        {
            var item = _context.Inventarios
                .Include(p => p.BienPatrimonial)
                .Include(p => p.Area)
                .Include(p => p.AnexoTipo)
                .Include(p => p.EstadoCondicion)
                .Include(p => p.Procedimiento)
                .FirstOrDefault(p => p.Id == inventarioId);
            return item;
        }
        public bool InventarioExists(int inventarioId)
        {
            return _context.Inventarios.Any(p => p.Id == inventarioId);

        }

        public IEnumerable<Inventario> GetInventariosForArea(int areaId)
        {
            var retornito = _context.Inventarios
                           .Where(c => c.AreaId == areaId)
                           .OrderBy(c => c.Area.Nombre);
            return retornito;

        }


        public ProcedimientoInventario GetProcedimientoBienById(int procedimientoBienId)
        {
            return _context.ProcedimientoBiens.FirstOrDefault(p => p.Id == procedimientoBienId);
        }

   

     

      

        public bool ProcedimientoBienesExists(int procedimientoBienId)
        {
            return _context.ProcedimientoBiens.Any(p => p.Id == procedimientoBienId);
        }

       

        public bool Save()
        {

            return _context.SaveChanges() >= 0;
        }

        public IEnumerable<Ajuste> GetAllAjustes()
        {
            var lista = _context.Ajustes
           .Include(a => a.AjusteTipo)          
           .ToList();
            return lista;
        }

        public Ajuste GetAjusteById(int ajusteId)
        {
            var item = _context.Ajustes
            .Include(p => p.AjusteTipo)                         
            .FirstOrDefault(p => p.Id == ajusteId);
            return item;
        }

        public void CreateAjuste(Ajuste ajuste)
        {
            if (ajuste == null)
            {
                throw new ArgumentNullException(nameof(ajuste));
            }
            _context.Ajustes.Add(ajuste);
        }

        public void UpdateAjuste(Ajuste ajuste)
        {
                _context.Update(ajuste);            
        }

        public bool AjusteExists(int ajusteId)
        {
            return _context.Ajustes.Any(p => p.Id == ajusteId);
        }

        //AjusteDetalles


        public IEnumerable<AjusteDetalle> GetAllAjusteDetalles()
        {
            var lista = _context.AjusteDetalles
                       .Include(a => a.Ajuste)
                       .Include(a => a.Ajuste.AjusteTipo)
                       .Include(a => a.AreaDestino)
                       .Include(a => a.AreaOrigen)
                       .Include(a => a.Inventario.BienPatrimonial)
                       .ToList();
            return lista;
        }

        //public IEnumerable<AjustoExtendidoDto> GetAllAjusteExtendidos()
        //{
        //    var lista = _context.AjusteDetalles
        //               .Include(a => a.Ajuste)
        //               .Include(a => a.AreaDestino)
        //               .Include(a => a.AreaOrigen)
        //               .Include(a => a.Inventario.BienPatrimonial)
        //               .ToList();
        //    return lista;
        //}

        public AjusteDetalle GetAjusteDetalleById(int ajusteDetalleId)
        {
            var item = _context.AjusteDetalles
                       .Include(a => a.Ajuste)
                       .Include(a => a.AreaDestino)
                       .Include(a => a.AreaOrigen)
                       .Include(a => a.Inventario)
                       .FirstOrDefault(p => p.Id == ajusteDetalleId);
            return item;

        }

        public void CreateAjusteDetalle(AjusteDetalle ajusteDetalle)
        {
            if (ajusteDetalle == null)
            {
                throw new ArgumentNullException(nameof(ajusteDetalle));
            }
            _context.AjusteDetalles.Add(ajusteDetalle);
        }

        public void UpdateAjusteDetalle(AjusteDetalle ajusteDetalle)
        {
            _context.Update(ajusteDetalle);
        }

        public Ajuste AjusteNuevoInventario(Inventario inventario)
        {
            var ajuste = new Ajuste();
            ajuste.AjusteTipoId = 25;
            ajuste.Justificacion = $"Alta de {inventario.BienPatrimonial.Denominacion}";
            ajuste.FechaRegistro = DateTime.Now;
            return ajuste;
        }
        public AjusteDetalle AjusteDetalleNuevoInventario(Ajuste ajuste, Inventario inventario)
        {
            var ajusteDetalle = new AjusteDetalle();
            ajusteDetalle.AjusteId = ajuste.Id;
            ajusteDetalle.InventarioId = inventario.Id;
            ajusteDetalle.CantidadAfectada = inventario.Cantidad;
            ajusteDetalle.AreaDestinoId = inventario.AreaId;
            return ajusteDetalle;
        }





    }
}
