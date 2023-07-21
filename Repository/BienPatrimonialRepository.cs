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





        public void CreateInventario(int bienPatrimonialId, int areaId, int anexoTipoId,
            int estadoCondicionId, int estadoBienId, Inventario inventario)
        {
            if (inventario == null)
            {
                throw new ArgumentNullException(nameof(inventario));
            }
            var bienPatrimonialString = _context.BienesPatrimoniales.Where(p => p.Id == bienPatrimonialId)
                .Select(x => x.Denominacion).Single();
            var areaString = _context.Areas.Where(p => p.Id == areaId)
                .Select(x => x.Nombre).Single();
            var anexoTipoString = _context.Enumerados.Where(p => p.Id == anexoTipoId)
                .Select(x => x.Valor).Single();
            var estadoCondicionString = _context.Enumerados.Where(p => p.Id == estadoCondicionId)
              .Select(x => x.Valor).Single();
            var estadoBienString = _context.Enumerados.Where(p => p.Id == estadoBienId)
           .Select(x => x.Valor).Single();
            inventario.BienPatrimonialId = bienPatrimonialId;
            inventario.BienPatrimonialString = bienPatrimonialString;
            inventario.AreaId = areaId;
            inventario.AreaString = areaString;
            inventario.AnexoTipoId = anexoTipoId;
            inventario.AnexoTipoString = anexoTipoString;
            inventario.EstadoCondicionId = estadoCondicionId;
            inventario.EstadoCondicionString = estadoCondicionString;
            inventario.EstadoBienId = estadoBienId;
            inventario.EstadoBienString = estadoBienString;
            _context.Inventarios.Add(inventario);
        }

  

        public void CreateProcedimientoBien(int bienPatrimonialId, int procedimientoId, ProcedimientoBien procedimientoBien)
        {
            if (procedimientoBien == null)
            {
                throw new ArgumentNullException(nameof(procedimientoBien));
            }
            var bienPatrimonialString = _context.BienesPatrimoniales.Where(p => p.Id == bienPatrimonialId)
                .Select(x => x.Denominacion).Single();
            //var categoriaString = _context.BienesPatrimoniales.Where(p => p.Id == bienPatrimonialId)
            //   .Select(x => x.Categoria).Single();
            var procedimientoString = _context.Procedimientos.Where(p => p.Id == procedimientoId)
                .Select(x => x.NombreReferencial).Single();           
            //var tipoProcedimientoString = _context.Procedimientos.Where(p => p.Id == procedimientoId)
             // .Select(x => x.ProcedimientoTipoString).Single();
            //var causalString = _context.Procedimientos.Where(p => p.Id == procedimientoId)
           //.Select(x => x.CausalString).Single();
            procedimientoBien.BienPatrimonialId = bienPatrimonialId;
            procedimientoBien.BienPatrimonialString = bienPatrimonialString;
            //procedimientoBien.CategoriaString = categoriaString;
            procedimientoBien.ProcedimientoId = procedimientoId;
            procedimientoBien.ProcedimientoString = procedimientoString;
            //procedimientoBien.ProcedimientoTipoString = tipoProcedimientoString;
            //procedimientoBien.CausalString = causalString;
            _context.ProcedimientoBiens.Add(procedimientoBien);

        }

        

       
        public IEnumerable<BienPatrimonial> GetAllBienes()
        {
            //return _context.BienesPatrimoniales.ToList();
            var lista = _context.BienesPatrimoniales
          .Include(a => a.Categoria)
          .Include(a => a.Procedimiento)
          .ToList();
            return lista;
        }

      

        public IEnumerable<Inventario> GetAllInventarios()
        {
            return _context.Inventarios.ToList();
        }

        public IEnumerable<ProcedimientoBien> GetAllProcedimientoBienes()
        {
            return _context.ProcedimientoBiens.ToList();

        }

       

      

        public BienPatrimonial GetBienById(int id)
        {
            //return _context.BienesPatrimoniales.FirstOrDefault(p => p.Id == id);
            var item =  _context.BienesPatrimoniales
              .Include(p => p.Categoria)
                   .Include(a => a.Procedimiento)
              .FirstOrDefault(p => p.Id == id);
            return item;

        }

        public IEnumerable<ProcedimientoBien> GetBienesByProcedimiento(int procedimientoId)
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
         return _context.Inventarios.FirstOrDefault(p => p.Id == inventarioId);

        }

        public IEnumerable<Inventario> GetInventariosForArea(int areaId)
        {
            var retornito = _context.Inventarios
                           .Where(c => c.AreaId == areaId)
                           .OrderBy(c => c.Area.Nombre);
            return retornito;

        }

        public ProcedimientoBien GetProcedimientoBienById(int procedimientoBienId)
        {
            return _context.ProcedimientoBiens.FirstOrDefault(p => p.Id == procedimientoBienId);
        }

   

        public IEnumerable<ProcedimientoBien> GetProcedimientosByBien(int bienPatrimonialId)
        {
            var retornito = _context.ProcedimientoBiens
              .Where(c => c.BienPatrimonialId == bienPatrimonialId)
              .OrderBy(c => c.BienPatrimonial.Categoria);
            return retornito;
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

        //Pruebita
        public void DarAlta(Alta alta)
        {
            if (alta == null)
            {
                throw new ArgumentNullException(nameof(alta));
            }

            var inv = new Inventario
            {
                Cantidad = alta.Inventario.Cantidad,
                AnexoTipo = alta.Inventario.AnexoTipo,
                EstadoCondicion = alta.Inventario.EstadoCondicion,
                EstadoBien = alta.Inventario.EstadoBien,
                AreaId = alta.Inventario.AreaId,
                BienPatrimonial = new BienPatrimonial
                {
                    Denominacion = alta.BienPatrimonial.Denominacion,
                    CodigoSBN = alta.BienPatrimonial.CodigoSBN,
                    Marca = alta.BienPatrimonial.Marca,
                    Modelo = alta.BienPatrimonial.Modelo,
                    Color = alta.BienPatrimonial.Color,
                    Observacion = alta.BienPatrimonial.Observacion,
                    Categoria = alta.BienPatrimonial.Categoria
                }
            };
            var procedimiento = new Procedimiento
            {
                NombreReferencial = alta.Procedimiento.NombreReferencial,
                ProcedimientoTipo = alta.Procedimiento.ProcedimientoTipo,
                Causal = alta.Procedimiento.Causal
        };
            var bienpatrimonialId = inv.BienPatrimonial.Id;
            var procedimientoId = procedimiento.Id;
            var procedimientoBien = new ProcedimientoBien
            {
                BienPatrimonialId = bienpatrimonialId,
                ProcedimientoId = procedimientoId
            };
            _context.Add(alta);                        
           
        }

    
    }
}
