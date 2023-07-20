using Microsoft.EntityFrameworkCore;
using SICPMonolithic.Data;
using SICPMonolithic.Interfaces;
using SICPMonolithic.Models;

namespace SICPMonolithic.Repository
{
    public class AreaRepository: IAreaRepository
    {
        private readonly AppDbContext _context;

        public AreaRepository(AppDbContext context)
        {
            _context = context;

        }
        public IEnumerable<Area> GetAllAreas()
        {
            //return _context.Areas.ToList();
            var lista = _context.Areas
          .Include(a => a.Sede)
          .Include(a => a.Dependencia)
          .Include(a => a.EstadoArea)
          .ToList();
            return lista;

        }

        public Area GetAreaById(int areaId)
        {
            //return _context.Areas.FirstOrDefault(p => p.Id == areaId);
            return _context.Areas
                .Include(p => p.Dependencia)
                     .Include(a => a.Sede)
                     .Include(a => a.EstadoArea)
                .FirstOrDefault(p => p.Id == areaId);
        }

        public void CreateArea(Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }            
            _context.Areas.Add(area);
        }
        public bool AreaExists(int areaId)
        {
            return _context.Areas.Any(p => p.Id == areaId);

        }
        public bool Save()
        {

            return _context.SaveChanges() >= 0;
        }

        public void UpdateArea(Area area)
        {
            _context.Update(area);
        }
    }
}
