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
            return _context.Areas.ToList();
        }

        public Area GetAreaById(int areaId)
        {
            return _context.Areas.FirstOrDefault(p => p.Id == areaId);

        }

        public void CreateArea(int sedeId, int dependenciaId, int estadoAreaId, Area area)
        {
            if (area == null)
            {
                throw new ArgumentNullException(nameof(area));
            }
            var sedeString = _context.Enumerados.Where(p => p.Id == sedeId)
                .Select(x => x.Valor).Single();
            var dependenciaString = _context.Enumerados.Where(p => p.Id == dependenciaId)
                .Select(x => x.Valor).Single();
            var estadoAreaString = _context.Enumerados.Where(p => p.Id == estadoAreaId)
              .Select(x => x.Valor).Single();
            area.SedeId = sedeId;
            area.DependenciaId = dependenciaId;
            area.EstadoAreaId = estadoAreaId;
            area.SedeString = sedeString;
            area.DependenciaString = dependenciaString;
            area.EstadoAreaString = estadoAreaString;

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

    }
}
