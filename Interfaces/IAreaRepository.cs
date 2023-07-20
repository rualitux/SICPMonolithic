using SICPMonolithic.Models;

namespace SICPMonolithic.Interfaces
{
    public interface IAreaRepository
    {
        IEnumerable<Area> GetAllAreas();
        void CreateArea(Area area);
        bool AreaExists(int areaId);
        Area GetAreaById(int areaId);
        public void UpdateArea(Area area);
        bool Save();

    }
}
