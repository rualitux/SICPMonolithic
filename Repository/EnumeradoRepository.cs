using SICPMonolithic.Data;
using SICPMonolithic.Interfaces;
using SICPMonolithic.Models;

namespace SICPMonolithic.Repository
{
    public class EnumeradoRepository: IEnumeradoRepository
    {
        private readonly AppDbContext _context;

        public EnumeradoRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Enumerado> GetAllEnumerados()
        {
            return _context.Enumerados.ToList();
        }

        public void CreateEnumerado(Enumerado enumerado)
        {
            if (enumerado == null)
            {
                throw new ArgumentNullException(nameof(enumerado));
            }
            _context.Enumerados.Add(enumerado);
        }
        public Enumerado GetEnumeradobyId(int id)
        {
            return _context.Enumerados.FirstOrDefault(p => p.Id == id);
        }

        public bool EnumeradoExists(int enumeradoId)
        {
            return _context.Enumerados.Any(p => p.Id == enumeradoId);
        }


        public bool Save()
        {

            return _context.SaveChanges() >= 0;
        }
    }
}
