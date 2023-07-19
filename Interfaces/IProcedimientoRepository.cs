using SICPMonolithic.Models;

namespace SICPMonolithic.Interfaces
{
    public interface IProcedimientoRepository
    {
        IEnumerable<Procedimiento> GetAllProcedimientos();
        void CreateProcedimiento(Procedimiento procedimiento);
        bool ProcedimientoExists(int procedimientoId);
        Procedimiento GetProcedimientoById(int procedimientoId);
        public IEnumerable<Procedimiento> GetAltas(int procTipoId);
        public void UpdateProcedimiento(Procedimiento procedimiento);

        bool Save();

    }
}
