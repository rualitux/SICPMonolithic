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



        //public void CreateBien(int enumeradoId, BienPatrimonial bien)
        //{
        //    if (bien == null)
        //    { 
        //        throw new ArgumentNullException(nameof(bien));                
        //    }
        //    var categoria = _context.Enumerados.Where(p => p.Id == enumeradoId)
        //        .Select(x=>x.Valor).Single();
        //    bien.Categoria= categoria;
        //    bien.EnumeradoId = enumeradoId;   

        //    _context.BienesPatrimoniales.Add(bien);
        //}
        public void CreateBien(BienPatrimonial bien)
        {
            if (bien == null)
            {
                throw new ArgumentNullException(nameof(bien));
            }
            //var categoria = _context.Enumerados.Where(p => p.Id == enumeradoId)
            //    .Select(x => x.Valor).Single();           
            //bien.Categoria = categoria;           
            //bien.EnumeradoId = enumeradoId;          
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

   

     

        public bool InventarioExists(int inventarioId)
        {
            return _context.Inventarios.Any(p => p.Id == inventarioId);

        }

        public bool ProcedimientoBienesExists(int procedimientoBienId)
        {
            return _context.ProcedimientoBiens.Any(p => p.Id == procedimientoBienId);
        }

       

        public bool Save()
        {

            return _context.SaveChanges() >= 0;
        }
     
    
    }
}
