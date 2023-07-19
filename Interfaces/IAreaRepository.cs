using SICPMonolithic.Models;

namespace SICPMonolithic.Interfaces
{
    public interface IAreaRepository
    {
        IEnumerable<Area> GetAllAreas();
        void CreateArea(int sedeId, int dependenciaId, int estadoAreaId, Area area);
        bool AreaExists(int areaId);
        Area GetAreaById(int areaId);
        bool Save();

    }
}
