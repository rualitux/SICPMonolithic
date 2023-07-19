using SICPMonolithic.Models;

namespace SICPMonolithic.Interfaces
{
    public interface IEnumeradoRepository
    {
        IEnumerable<Enumerado> GetAllEnumerados();
        void CreateEnumerado(Enumerado enumerado);
        Enumerado GetEnumeradobyId(int id);

        bool EnumeradoExists(int enumeradoId);
        bool Save();

    }
}
