using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using SICPMonolithic.Data;
using SICPMonolithic.Dtos;
using SICPMonolithic.Interfaces;
using SICPMonolithic.Models;
using System.Net.Mime;

namespace SICPMonolithic.Repository
{
    public class ProcedimientoRepository: IProcedimientoRepository
    {
        private readonly AppDbContext _context;

        public ProcedimientoRepository(AppDbContext context)
        {
            _context = context;
        }
        public void CreateProcedimiento(Procedimiento procedimiento)
        {

            if (procedimiento == null)
            {
                throw new ArgumentNullException(nameof(procedimiento));
            }
            _context.Procedimientos.Add(procedimiento);            
        }
        public void UpdateProcedimiento(Procedimiento procedimiento)
        {
            _context.Update(procedimiento);
        }

        public IEnumerable<Procedimiento> GetAllProcedimientos()
        {
            var lista = _context.Procedimientos
            .Include(a => a.ProcedimientoTipo)
            .Include(a => a.Causal)
            .ToList();
            return lista;
        }
        public IEnumerable<Procedimiento> GetAltas(int procTipoId)
        {
            var altas = _context.Procedimientos
                        .Include(a => a.ProcedimientoTipo)
                        .Where(p => p.ProcedimientoTipoId == procTipoId)
                        .ToList();
            return altas;
        }

        public Procedimiento GetProcedimientoById(int procedimientoId)
        {
            return _context.Procedimientos
                .Include(p=>p.ProcedimientoTipo)
                     .Include(a => a.Causal)
                .FirstOrDefault(p => p.Id == procedimientoId);
            //var sacada = _context.Procedimientos
            //    .Include(c=> c.ProcedimientoTipo).                
            //    FirstOrDefault(p => p.ProcedimientoTipoId == procedimientoId);
            //return sacada;
        }

        public bool ProcedimientoExists(int procedimientoId)
        {
            return _context.Procedimientos.Any(p => p.Id == procedimientoId);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }
    }
}
